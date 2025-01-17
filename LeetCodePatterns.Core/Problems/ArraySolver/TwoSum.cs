using System;

namespace LeetCodePatterns.Core.Problems.ArraySolver;

public static class TwoSum
{
    public static int[] Solve(int[] nums, int target)
    {
        if(nums == null || nums.Length < 2)
        {
            throw new ArgumentException("Input array must have at least two elements.");
        }
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if(dict.ContainsKey(complement))
            {
                return new int[] { dict[complement], i };
            }
            dict[nums[i]] = i;
        }
        return Array.Empty<int>();
    }
}
