using System;

namespace LeetCodePatterns.Core.Problems.StringSolver;

public class IsPalindrome
{
    public static bool Solve(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        int left = 0;
        int right = str.Length - 1;
        while (left < right)
        {
            // Move the left pointer if the current character is not alphanumeric
            if (!char.IsLetterOrDigit(str[left]))
            {
                left++;
                continue;
            }

            // Move the right pointer if the current character is not alphanumeric
            if (!char.IsLetterOrDigit(str[right]))
            {
                right--;
                continue;
            }
            // Compare characters (case-insensitive)
            if (char.ToLowerInvariant(str[left]) != char.ToLowerInvariant(str[right]))
            {
                return false;
            }
            // Move both pointers inward
            left++;
            right--;
        }
        return true;
    }

}
