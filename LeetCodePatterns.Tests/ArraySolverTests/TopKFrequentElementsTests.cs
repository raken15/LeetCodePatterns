using System;

namespace LeetCodePatterns.Tests.ArraySolverTests;

public class TopKFrequentElementsTests
{
    [Theory]
    [InlineData(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
    [InlineData(new[] { 1 }, 1, new[] { 1 })]
    [InlineData(new[] { 1, 1, 4, 2, 2, 1, 3, 3 }, 3, new[] { 1, 2, 3 })]
    [InlineData(new[] { 4, 5, 4, 5, 4, 5 }, 1, new[] { 5 })]
    public void Solve_ReturnsTopKFrequentElements_WhenValidInput(
        int[] inputArr, int k, int[] expected)
    {
        var result = TopKFrequentElements.Solve(inputArr, k);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, 2)]
    [InlineData(new int[] { }, 2)]
    public void Solve_ThrowsArgumentException_WhenInputArrayIsNullOrEmpty(
        int[] inputArr, int k)
    {
        Assert.Throws<ArgumentException>(() => TopKElementsMinHeap.Solve(inputArr, k));
    }

    [Theory]
    [InlineData(new[] { 1 }, 0)]
    [InlineData(new[] { 1 }, -1)]
    public void Solve_ThrowsArgumentException_WhenKIsZeroOrLessThanZero(
        int[] inputArr, int k)
    {
        Assert.Throws<ArgumentException>(() => TopKFrequentElements.Solve(inputArr, k));
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 7)]
    public void Solve_ReturnsAllElementsDescending_WhenKIsEqualOrGreaterToLengthOfInputArray(
    int[] inputArr, int k)
    {
        int[] expected = inputArr.OrderByDescending(x => x).ToArray();

        var result = TopKElementsMinHeap.Solve(inputArr, k);

        Assert.Equal(expected, result);
    }
}
