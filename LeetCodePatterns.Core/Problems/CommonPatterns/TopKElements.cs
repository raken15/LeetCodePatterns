using LeetCodePatterns.Core.Helpers;

namespace LeetCodePatterns.Core.Problems.CommonPatterns;


public class TopKElementsMinHeap
{
        /// <summary>
        /// Given an array of integers and an integer k, return the k largest elements in the array.
        /// </summary>
        /// <param name="inputArr">The input array of integers</param>
        /// <param name="k">The number of largest elements to return</param>
        /// <returns>The k largest elements in the array, in descending order</returns>
        /// <exception cref="ArgumentException">Thrown when the input array is null or empty, or k is less than or equal to 0</exception>
    public static int[] Solve(int[] inputArr, int k)
    {
        if (k <= 0 || inputArr == null || inputArr.Length == 0)
        {
            throw new ArgumentException("Input array must contain at least one element, and k must be greater than 0.");
        }
        // Handle case when k is greater than nums.Length by returning the entire array sorted
        if (k > inputArr.Length)
        {
            k = inputArr.Length; // Adjust k to be the size of the array
        }
        // Create a MinHeap of capacity K
        var minHeap = new MinHeap<int>(k+1);
        // Process each element in the array
        foreach (var num in inputArr)
        {
            // Add the number to the heap
            minHeap.Insert(num);

            // If the heap exceeds size K, remove the smallest element
            if (minHeap.Size > k)
            {
                minHeap.ExtractMin();
            }
        }
        // The heap now contains the top K elements
        var topKElements = new int[k];
        for (int i = k-1; i >= 0; i++)
        {
            topKElements[i] = minHeap.ExtractMin();
        }

        return topKElements;
    }
}
