using LeetCodePatterns.Core.Helpers;

namespace LeetCodePatterns.Core.Problems.ArraySolver;

public class TopKFrequentElements
{
    /// <summary>
    /// Given an array of integers nums and an integer k, return the k most frequent elements in the array.
    /// </summary>
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
        if(k > frequencyMap.Count)
        {
            k = frequencyMap.Count;
        }
        // Create a MinHeap of capacity K
        var minHeap = new MinHeap<(int, int)>(k + 1);
        // Process each element in the array
        foreach (var kvp in frequencyMap)
        {
            // Add the number to the heap
            minHeap.Insert((kvp.Value, kvp.Key));

            // If the heap exceeds size K, remove the smallest element
            if (minHeap.Size > k)
            {
                minHeap.ExtractMin();
            }
        }
        // The heap now contains the top K elements
        var topKElements = new int[k];
        for (int i = k - 1; i >= 0; i--)
        {
            topKElements[i] = minHeap.ExtractMin().Item2;
        }

        return topKElements;
    }

}
