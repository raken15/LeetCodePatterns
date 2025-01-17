using System;

namespace LeetCodePatterns.Tests.StringSolverTests;

public class IsPalindromeTests
{
    [Theory]
    [InlineData("racecar", true)]
    [InlineData("race a car", false)]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData(" ", true)]
    [InlineData("", true)]
    [InlineData("0", true)]
    [InlineData("1001", true)]
    [InlineData("00", true)]
    [InlineData("0P", false)]
    [InlineData(".,", true)]
    public void Solve_ShouldReturnExpectedResult(string input, bool expectedResult)
    {
        var result = IsPalindrome.Solve(input);
        Assert.Equal(expectedResult, result);
    }
    [Theory]
    [InlineData(null)]
    public void Solve_ThrowArgumentException_WhenInvalidInput(string input)
    {
        Assert.Throws<ArgumentNullException>(() => IsPalindrome.Solve(input));
    }
}
