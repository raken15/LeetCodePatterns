using LeetCodePatterns.Core.Helpers;

namespace LeetCodePatterns.Core.Problems.ArraySolver;

public class TopKFrequentElements
{
    /// <summary>
    /// Given an array of integers nums and an integer k, return the k most frequent elements in the array.
    /// </summary>
    public static List<int> Solve(int[] inputArr, int k)
    {
        if (k <= 0 || inputArr == null || inputArr.Length < k)
        {
            throw new ArgumentException("Input array must have at least k elements, and k can't be less than 1");
        }
        // Handle case when k is greater than nums.Length by returning the entire array sorted
        if (k > inputArr.Length)
        {
            k = inputArr.Length; // Adjust k to be the size of the array
        }
        var frequencyMap = new Dictionary<int, int>();
        foreach (var num in inputArr)
        {
            if (frequencyMap.ContainsKey(num))
            {
                frequencyMap[num]++;
            }
            else
            {
                frequencyMap[num] = 1;
            }
        }
        // Create a MinHeap of capacity K
        var minHeap = new MinHeap<(int, int)>(k + 1);
        // Process each element in the array
        foreach (var num in inputArr)
        {
            // Add the number to the heap
            minHeap.Insert((num, frequencyMap[num]));

            // If the heap exceeds size K, remove the smallest element
            if (minHeap.Size > k)
            {
                minHeap.ExtractMin();
            }
        }
        // The heap now contains the top K elements
        var topKElements = new List<int>();
        while (!minHeap.IsEmpty)
        {
            topKElements.Add(minHeap.ExtractMin().Item1);
        }
        topKElements.Reverse(); // To get the largest elements in descending order

        return topKElements;
    }

}
