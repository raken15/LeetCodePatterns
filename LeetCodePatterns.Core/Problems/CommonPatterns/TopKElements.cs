using LeetCodePatterns.Core.Helpers;

namespace LeetCodePatterns.Core.Problems.CommonPatterns;


public class TopKElements
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
        k = Math.Min(k, inputArr.Length); // Limit k to the size of the input array
        var minHeap = new MinHeap<int>(k);
        foreach (var num in inputArr)
        {
            if (minHeap.Size < k)
            {
                minHeap.Insert(num);
            }
            else if (num > minHeap.Peek())
            {
                minHeap.ExtractMin();
                minHeap.Insert(num);
            }
        }
        var topKElements = new int[k];
        for (int i = k-1; i >= 0; i--) // descending order
        {
            topKElements[i] = minHeap.ExtractMin();
        }

        return topKElements;
    }
}
