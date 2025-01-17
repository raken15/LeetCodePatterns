using System;

namespace LeetCodePatterns.Core.Problems.StringSolver;

public class IsPalindrome
{
    public static bool Solve(string s)
    {
        if (s == null)
        {
            throw new ArgumentNullException(nameof(s));
        }
        int left = 0;
        int right = s.Length - 1;
        while (left < right)
        {
            if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

}
