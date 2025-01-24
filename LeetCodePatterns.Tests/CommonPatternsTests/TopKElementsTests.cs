namespace LeetCodePatterns.Tests.CommonPatternsTests;

public class TopKElementsTests
{
    [Theory]
    [InlineData(new int[] { 7 }, 1, new int[] { 7 })]
    [InlineData(new int[] { 7, 9 }, 2, new int[] { 9, 7 })]
    [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] { 3, 2 })]
    [InlineData(new int[] { 1, 1, 5, 4, 2, 3 }, 3, new int[] { 5, 4, 3 })]
    [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 4, new int[] { 3, 2, 2, 1 })]
    public void Solve_ReturnsTopKElements_WhenValidInput(
        int[] inputArr, int k, int[] expected)
    {
        var result = TopKElements.Solve(inputArr, k);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(null, 2)]
    [InlineData(new int[] { }, 2)]
    public void Solve_ThrowsArgumentException_WhenInputArrayIsNullOrEmpty(
        int[] inputArr, int k)
    {
        Assert.Throws<ArgumentException>(() => TopKElements.Solve(inputArr, k));
    }

    [Theory]
    [InlineData(new int[] { 1 }, 0)]
    [InlineData(new int[] { 1 }, -1)]
    public void Solve_ThrowsArgumentException_WhenKIsZeroOrLessThanZero(
        int[] inputArr, int k)
    {
        Assert.Throws<ArgumentException>(() => TopKElements.Solve(inputArr, k));
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, 7)]
    public void Solve_ReturnsAllElementsDescending_WhenKIsEqualOrGreaterToLengthOfInputArray(
        int[] inputArr, int k)
    {
        int[] expected = inputArr.OrderByDescending(x => x).ToArray();

        var result = TopKElements.Solve(inputArr, k);

        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, 2, new int[] { 2, 1 })]
    [InlineData(new int[] { 1, 2, 2  }, 2, new int[] { 2, 2 })]
    [InlineData(new int[] { 2, 2, 1, 1, 3, 3 }, 3, new int[] { 3, 3, 2 })]
    public void Solve_ReturnsKElementsDescending_HaveElementsWithEqualValue(
    int[] inputArr, int k, int[] expected)
    {
        var result = TopKElements.Solve(inputArr, k);

        Assert.Equal(expected, result);
    }
}
