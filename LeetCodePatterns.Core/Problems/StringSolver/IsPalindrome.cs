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

        var trimmedString = new string(s.Where(c => char.IsLetterOrDigit(c)).ToArray());
        int left = 0;
        int right = trimmedString.Length - 1;
        while (left < right)
        {
            if (char.ToLowerInvariant(trimmedString[left]) != char.ToLowerInvariant(trimmedString[right]))
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

}
