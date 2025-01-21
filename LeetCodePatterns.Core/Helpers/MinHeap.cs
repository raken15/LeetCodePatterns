namespace LeetCodePatterns.Core.Helpers;

public class MinHeap<T> where T : IComparable
{
    private List<T> _elements;
    private int LastIndex => _elements.Count - 1;
    public int Size => _elements.Count;
    public bool IsEmpty => _elements.Count == 0;
    /// <summary>
    /// Initializes a new instance of the MinHeap class with an optional initial capacity.
    /// </summary>
    /// <param name="initialCapacity">
    /// The initial number of elements that the heap can store. If not specified,
    /// the heap will use dynamic resizing to accommodate elements.
    /// </param>
    public MinHeap(int? initialCapacity = null)
    {
        _elements = initialCapacity.HasValue
            ? new List<T>(initialCapacity.Value) // Initialize with the given capacity
            : new List<T>();                    // Default to dynamic resizing
    }
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
    public void HeapifyUp(int index)
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
    public void Clear() => _elements.Clear();
}
