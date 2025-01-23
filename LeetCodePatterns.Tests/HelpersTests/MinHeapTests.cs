using System;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;

namespace LeetCodePatterns.Tests.HelpersTests;

public class MinHeapTests
{
    #region Constructor
    [Fact]
    public void Constructor_InitializesEmptyHeap_WhenNoInitialCapacityProvided()
    {
        var minHeap = new MinHeap<int>();

        Assert.NotNull(minHeap);
        Assert.True(minHeap.IsEmpty);
        Assert.Equal(0, minHeap.Size);
    }

    [Theory]
    [InlineData(10)]
    public void Constructor_InitializesEmptyHeapWithCapacity_WhenValidInitialCapacityProvided(int initialCapacity)
    {
        var minHeap = new MinHeap<int>(initialCapacity);

        Assert.NotNull(minHeap);
        Assert.True(minHeap.IsEmpty);
        Assert.Equal(0, minHeap.Size);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Constructor_ThrowsArgumentOutOfRangeException_WhenInvalidInitialCapacityProvided(int invalidCapacity)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new MinHeap<int>(invalidCapacity));
    }

    #endregion Constructor
    #region Test Helper methods
    [Theory]
    [InlineData(typeof(int), new int[] { 4, 2, 9 }, 2)]
    [InlineData(typeof(double), new double[] { 4.5, 2.1, 9.8 }, 2.1)]
    [InlineData(typeof(string), new string[] { "hello", "abc", "xyz" }, "abc")]
    [InlineData(typeof(bool), new bool[] { true, false, true }, false)]
    public void CreateMinHeap_ValidValues_ReturnsMinHeap(Type expectedHeapType, Array inputValues, object expectedMinValue)
    {
        // Act
        var minHeap = CreateMinHeap((dynamic)inputValues);
        var resultMinimumValue = minHeap.Peek();
        var resultType = minHeap.GetType().GetGenericArguments()[0];

        // Assert
        Assert.NotNull(minHeap);
        Assert.Equal(inputValues.Length, minHeap.Size);
        Assert.Equal(expectedHeapType, resultType);
        Assert.NotNull(resultMinimumValue);
        Assert.Equal(expectedMinValue, resultMinimumValue);
    }
    #endregion Test Helper methods
    #region Peek
    [Fact]
    public void Peek_EmptyHeap_ThrowsInvalidOperationException()
    {
        var minHeap = new MinHeap<int>();

        Assert.Throws<InvalidOperationException>(() => minHeap.Peek());
    }
    [Theory]
    [InlineData(new int[] { 4 }, 4)]
    [InlineData(new double[] { 22.1 }, 22.1)]
    [InlineData(new string[] { "hello" }, "hello")]
    [InlineData(new bool[] { true }, true)]
    [InlineData(new int[] { -7, 22 }, -7)]
    [InlineData(new int[] { 33, 1, 5, 0 }, 0)]
    public void Peek_NonEmptyHeap_DoesNotRemoveElement(
        Array inputValues, object expectedSmallest)
    {
        var minHeap = CreateMinHeap((dynamic)inputValues);
        var expectedSize = minHeap.Size;
        
        var resultSmallest = minHeap.Peek();

        Assert.Equal(expectedSize, minHeap.Size);
        Assert.Equal(expectedSmallest, resultSmallest);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 9 }, 1)]
    [InlineData(new double[] { 4.7, 6.1, 9.8 }, 4.7)]
    [InlineData(new string[] { "hello", "abc", "xyz" }, "abc")]
    [InlineData(new bool[] { true, true, false }, false)]
    [InlineData(new int[] { 4 }, 4)]
    [InlineData(new int[] { -7, 22 }, -7)]
    public void Peek_NonEmptyHeapInt_DoesNotChangeSmallest(Array inputValues, object expectedSmallest)
    {
        var minHeap = CreateMinHeap((dynamic)inputValues);

        var firstPeek = minHeap.Peek();
        var secondPeek = minHeap.Peek();

        Assert.Equal(expectedSmallest, firstPeek);
        Assert.Equal(expectedSmallest, secondPeek);
    }

    [Theory]
    [InlineData(new int[] { 4, 2, 9 }, 2)]
    [InlineData(new double[] { 4.5, 6.1, 9.8 }, 4.5)]
    [InlineData(new string[] { "hello", "abc", "xyz" }, "abc")]
    [InlineData(new bool[] { true, true, false }, false)]
    [InlineData(new int[] { 4 }, 4)]
    [InlineData(new int[] { -7, 22 }, -7)]
    public void Peek_NonEmptyHeap_ReturnsSmallestElement(Array inputValues, object expectedSmallest)
    {
        // Arrange
        var minHeap = CreateMinHeap((dynamic)inputValues);

        // Act
        var smallestElement = minHeap.Peek();

        // Assert
        Assert.Equal(expectedSmallest, smallestElement);
    }
    #endregion Peek
    #region ExtractMin
    [Fact]
    public void ExtractMin_EmptyHeap_ThrowsInvalidOperationException()
    {
        var minHeap = new MinHeap<int>();

        Assert.Throws<InvalidOperationException>(() => minHeap.ExtractMin());
    }
    [Theory]
    [InlineData(new int[] { 4, 2, 9 }, 2, 4, 2)]
    [InlineData(new double[] { 4.5, 6.1, 9.8 }, 4.5, 6.1, 2)]
    [InlineData(new string[] { "hello", "abc", "xyz" }, "abc", "hello", 2)]
    [InlineData(new bool[] { true, true, false }, false, true, 2)]
    [InlineData(new int[] { -7, 22 }, -7, 22, 1)]
    public void ExtractMin_NonEmptyHeap_ReturnsSmallestElementAndRemovesIt(
        Array inputValues, object expectedSmallest, object expectedNextSmallestOnTop, int expectedSize)
    {
        // Arrange
        var minHeap = CreateMinHeap((dynamic)inputValues);

        // Act
        var resultSmallestElement = minHeap.ExtractMin();
        var resultSize = minHeap.Size;
        var resultNextSmallestOnTop = minHeap.Peek();

        // Assert
        Assert.Equal(expectedSmallest, resultSmallestElement);
        Assert.Equal(expectedSize, resultSize);
        Assert.Equal(expectedNextSmallestOnTop, resultNextSmallestOnTop);
    }
    [Theory]
    [InlineData(new int[] { 4, 2, 9 }, 2, 4)]
    [InlineData(new double[] { 4.5, 6.1, 9.8 }, 4.5, 6.1)]
    [InlineData(new string[] { "hello", "abc", "xyz" }, "abc", "hello")]
    [InlineData(new bool[] { true, true, false }, false, true)]
    [InlineData(new int[] { -7, 22 }, -7, 22)]
    public void ExtractMin_NonEmptyHeap_SmallestElementChangedAfterExtractMin(
        Array inputValues, object expectedSmallest, object expectedNextSmallest)
    {
        var minHeap = CreateMinHeap((dynamic)inputValues);

        var firstPeek = minHeap.Peek();
        var extractedSmallest = minHeap.ExtractMin();
        var secondPeek = minHeap.Peek();

        Assert.Equal(expectedSmallest, firstPeek);
        Assert.Equal(expectedSmallest, extractedSmallest);
        Assert.Equal(expectedNextSmallest, secondPeek);
    }
    #endregion ExtractMin
    #region Insert
    [Theory]
    [InlineData(5)]
    [InlineData(3.5)]
    [InlineData(true)]
    [InlineData("hello")]
    public void Insert_EmptyHeap_MakesHeapNonEmpty<T>(T inputValue) where T : IComparable
    {
        var minHeap = new MinHeap<T>();
        
        minHeap.Insert(inputValue);

        Assert.False(minHeap.IsEmpty);
        Assert.Equal(1, minHeap.Size);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(2.5)]
    [InlineData(false)]
    [InlineData("hello there")]
    public void Insert_EmptyHeap_SetsElementAsRoot<T>(T inputValue) where T : IComparable
    {
        var minHeap = new MinHeap<T>();

        minHeap.Insert(inputValue);
        var smallestElement = minHeap.Peek();

        Assert.Equal(inputValue, smallestElement);
    }
    [Theory]
    [InlineData(new int[] { 50, 80 }, 50 )]
    [InlineData(new int[] { 50, 80, 40 }, 40)]
    [InlineData(new double[] { 20.1, 3.3 }, 3.3 )]
    [InlineData(new string[] { "zoo", "apple", "banana" }, "apple" )]
    [InlineData(new bool[] { true, false }, false )]
    public void Insert_SmallerValue_BecomesRoot<T>(Array inputValues, object expectedSmallest) where T : IComparable
    {
        var minHeap = new MinHeap<T>();
        foreach (var value in inputValues)
        {
            minHeap.Insert((dynamic)value);
        }

        var smallestElement = minHeap.Peek();

        Assert.NotNull(smallestElement);
        Assert.Equal(expectedSmallest, smallestElement);
    }
    [Fact]
    public void Insert_MinValueEdgeCase_InsertsCorrectly()
    {
        var minHeap = new MinHeap<int>();
        minHeap.Insert(int.MinValue);

        var smallestElement = minHeap.Peek();

        Assert.Equal(int.MinValue, smallestElement);
    }
    #endregion Insert
    #region Clear
    [Fact]
    public void Clear_EmptyHeap_DoesNothing()
    {
        var minHeap = new MinHeap<int>();
        minHeap.Clear();

        Assert.True(minHeap.IsEmpty);
    }

    [Theory]
    [InlineData(new int[] { 5, 10, 20 })]
    [InlineData(new double[] { 4.5, 6.7 })]
    [InlineData(new bool[] { false, true })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    public void Clear_NonEmptyHeap_MakesHeapEmpty(
        Array inputValues)
    {
        var minHeap = CreateMinHeap((dynamic)inputValues);

        minHeap.Clear();

        Assert.True( minHeap.IsEmpty);
    }
    #endregion Clear
    #region Helper Methods
    private MinHeap<T> CreateMinHeap<T>(T[] inputValues) where T : IComparable
    {
        var minHeap = new MinHeap<T>();
        foreach (var value in inputValues)
        {
            minHeap.Insert(value);
        }
        return minHeap;
    }
    #endregion Helper Methods
}
