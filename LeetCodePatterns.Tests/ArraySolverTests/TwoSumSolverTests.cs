namespace LeetCodePatterns.Tests.ArraySolverTests;

public class TwoSumSolverTests
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 9, new int[] { 3, 4 })]
    [InlineData(new int[] { 8, 5, 3, 7 }, 12, new int[] { 1, 3 })]
    public void TwoSum_CorrectIndicesReturned(int[] nums, int target, int[] expectedIndices)
    {
        var result = TwoSumSolver.Solve(nums, target);
        Assert.Equal(expectedIndices, result);
    }
}
