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
        k = Math.Min(k, frequencyMap.Count); // Limit k to the size of the frequencyMap
        var minHeap = new MinHeap<(int, int)>(k);
        foreach (var kvp in frequencyMap)
        {
            if (minHeap.Size < k)
            {
                minHeap.Insert((kvp.Value, kvp.Key));
            }
            // Replace the smallest element in the heap if:
            // - The current frequency is higher than the smallest frequency in the heap, or
            // - The frequencies are equal, but the current key is larger.
            else if (kvp.Value > minHeap.Peek().Item1 || 
                     (kvp.Value == minHeap.Peek().Item1 && kvp.Key > minHeap.Peek().Item2))
            {
                minHeap.ExtractMin();
                minHeap.Insert((kvp.Value, kvp.Key));
            }
        }
        var topKElements = new int[k];
        for (int i = k - 1; i >= 0; i--) // descending order
        {
            topKElements[i] = minHeap.ExtractMin().Item2;
        }

        return topKElements;
    }

}
