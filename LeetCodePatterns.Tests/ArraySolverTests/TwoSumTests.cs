namespace LeetCodePatterns.Tests.ArraySolverTests;

public class TwoSumTests
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 9, new int[] { 3, 4 })]
    [InlineData(new int[] { 8, 5, 3, 7 }, 12, new int[] { 1, 3 })]
    public void Solve_CorrectIndicesReturned_WhenSolutionExists(int[] nums, int target, int[] expectedIndices)
    {
        var result = TwoSum.Solve(nums, target);
        Assert.Equal(expectedIndices, result);
    }
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 20)]
    [InlineData(new int[] { 3, 2, 4 }, -1)]
    [InlineData(new int[] { 3, 2, 4 }, 3)]
    public void Solve_ShouldReturnEmptyArray_WhenTargetCannotBeAchieved(int[] nums, int target)
    {
        var result = TwoSum.Solve(nums, target);
        Assert.Empty(result);
    }
    [Theory]
    [InlineData(new int[] { 6 }, 2)]
    [InlineData(new int[] { }, 2)]
    [InlineData(null, 2)]
    public void Solve_ThrowArgumentException_WhenInvalidInput(int[] nums, int target)
    {
        Assert.Throws<ArgumentException>(() => TwoSum.Solve(nums, target));
    }
}
