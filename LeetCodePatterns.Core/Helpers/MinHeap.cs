namespace LeetCodePatterns.Core.Helpers;

/// <summary>
/// Represents a minimum heap data structure with the following properties:
/// 1. The parent node is always smaller than or equal to its children.
/// 2. The root element is the smallest element in the heap.
/// 3. The heap is a complete binary tree, meaning all levels are fully filled except the last one,
///    which is filled from left to right.
/// </summary>
/// <remarks>
/// This implementation is NOT thread-safe. If multiple threads need to access 
/// the heap simultaneously, synchronization should be handled externally.
/// </remarks>
/// <typeparam name="T">The type of elements in the heap. Must implement <see cref="IComparable"/>.</typeparam>
public class MinHeap<T> where T : IComparable
{
    #region Constants
    private const int MAX_CAPACITY = int.MaxValue / 2;
    #endregion Constants
    #region Fields and Properties
    private List<T> _elements;
    private int LastIndex => _elements.Count - 1;
    public int Size => _elements.Count;
    public bool IsEmpty => _elements.Count == 0;
    #endregion Fields and Properties
    #region Constructor
    /// <summary>
    /// Initializes a new instance of the MinHeap class with an optional initial capacity.
    /// If no initial capacity is provided, an empty list is created.
    /// </summary>
    /// <param name="initialCapacity">
    /// The initial capacity of the heap. If null, the heap starts with an empty list.
    /// The capacity must be greater than zero and cannot exceed the maximum allowed capacity.
    /// </param>
    /// <remarks>
    /// When elements are inserted into the heap, and the number of elements exceeds the initial capacity,
    /// the internal list will automatically resize to accommodate the new elements. This resizing happens dynamically
    /// and may incur some performance overhead as the capacity increases.
    /// </remarks>
    public MinHeap(int? initialCapacity = null)
    {
        if (initialCapacity == null)
        {
            // Use an empty list if no initial capacity is specified
            _elements = new List<T>();
        }
        else
        {
            int capacity = initialCapacity.Value;

            // Validate the provided capacity
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), "Capacity must be greater than zero.");
            }

            if (capacity > MAX_CAPACITY)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity), $"Capacity cannot exceed {MAX_CAPACITY}.");
            }

            // Initialize the internal list with the given capacity
            _elements = new List<T>(MAX_CAPACITY);
        }
    }
    #endregion Constructor
    #region Public Methods
    /// <summary>
    /// Returns the root element of the heap without removing it.
    /// </summary>
    /// <returns>The smallest element in the heap.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the heap is empty.
    /// This exception is thrown when the heap is empty and the Peek() method is called.</exception>
    public T Peek()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        return _elements[0];
    }
    /// <summary>
    /// Adds a new element to the end of the heap and
    /// restores the heap property by moving the element upward.
    /// </summary>
    /// <remarks>
    /// The minimum heap is a data structure where the smallest items are close to the top.
    /// </remarks>
    /// <param name="value"></param>
    public void Insert(T value)
    {
        // Add the new element to the end of the heap
        _elements.Add(value);
        // Move the element upwards to maintain the heap property
        HeapifyUp(LastIndex);
    }
    /// <summary>
    /// Returns and removes the smallest element from the heap.
    /// Also handle edge cases that the heap is empty or have only one element
    /// </summary>
    /// <returns>The smallest element in the heap.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the heap is empty.
    /// This exception is thrown from the call to Peek().</exception>
    public T ExtractMin()
    {
        T min = Peek();
        _elements[0] = _elements[LastIndex];
        _elements.RemoveAt(LastIndex);
        if (!IsEmpty)
        {
            HeapifyDown(0);
        }
        HeapifyDown(0);
        return min;
    }
    public void Clear() => _elements.Clear();
    #endregion Public Methods
    #region Private Methods
    /// <summary>
    /// Restore the heap property after inserting a new element into the heap.
    /// </summary>
    /// <remarks>
    /// In a min heap, the parent node is always smaller than or equal to its children.
    /// Starting from the newly inserted element, check if it is smaller than its parent.
    /// If it is, swap it with the parent and move up the tree until the heap property is maintained.
    /// The loop terminates naturally using break when the condition is satisfied:
    /// the inserted element is no longer smaller than its parent.
    /// </remarks>
    /// <param name="index">The index of the element to be restored in the heap.</param>
    /// <remarks>
    /// The node index in binary heap is like a node in binary tree and is represented as:
    /// The left child of a node at index i is located at index 2i + 1.
    /// The right child of a node at index i is located at index 2i + 2.
    /// The parent of a node at index i is located at index(i - 1) / 2.
    /// </remarks>
    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (_elements[index].CompareTo(_elements[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
            }
            else
            {
                break;
            }
        }
    }
    /// <summary>
    /// Restores the heap property after removing the root element from the heap.
    /// This function ensures that the heap property is maintained by comparing the current node
    /// with its smallest child and swapping if necessary, continuing down the tree.
    /// </summary>
    /// <remarks>
    /// In a min heap, the parent node is always smaller than or equal to its children.
    /// The left child of a node at index i is located at index 2i + 1.
    /// The right child of a node at index i is located at index 2i + 2.
    /// The parent of a node at index i is located at index (i - 1) / 2.
    /// And the children are starting with the left child.
    /// </remarks>
    /// <param name="index">The index of the element to be restored in the heap.</param>
    private void HeapifyDown(int index)
    {
        int maxValidIndex = LastIndex;
        int leftChildIndex = 2 * index + 1;

        // Loop as long as the current node has at least one child
        while (leftChildIndex <= maxValidIndex)
        {
            int rightChildIndex = 2 * index + 2;
            int smallestChildIndex = leftChildIndex;

            // Check if the right child exists and is smaller than the left child
            if (rightChildIndex <= maxValidIndex
                && _elements[rightChildIndex].CompareTo(_elements[leftChildIndex]) < 0)
            {
                smallestChildIndex = rightChildIndex;
            }

            // If the current node is smaller than or equal to the smallest child, the heap is valid
            if (_elements[index].CompareTo(_elements[smallestChildIndex]) <= 0)
            {
                break;
            }

            // Swap the current node with the smallest child
            Swap(index, smallestChildIndex);

            // Move the index down to the smallest child
            index = smallestChildIndex;
            // Update the left child index after swapping to the smallest child
            leftChildIndex = 2 * index + 1;
        }
    }
    /// <summary>
    /// Swap the elements at two given indices in the heap.
    /// This helper function is used in both HeapifyUp and HeapifyDown.
    /// </summary>
    /// <param name="index1">The first index to be swapped.</param>
    /// <param name="index2">The second index to be swapped.</param>
    private void Swap(int index1, int index2)
    {
        T temp = _elements[index1];
        _elements[index1] = _elements[index2];
        _elements[index2] = temp;
    }
    #endregion Private Methods
}
