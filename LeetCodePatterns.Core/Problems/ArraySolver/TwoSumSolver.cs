using System;

namespace LeetCodePatterns.Core.Problems.ArraySolver;

public class TwoSumSolver
{
    public int[] TwoSum(int[] nums, int target)
    {
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
