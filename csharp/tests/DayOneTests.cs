using code;

namespace tests;

public class DayOneTests
{
    [Fact]
    public async Task ShouldSolveExample()
    {
        var result = await DayOne.SolveAsync(50, "day1_test.txt");
        Assert.Equal(3, result);
    }

    [Fact]
    public async Task ShouldSolvePartTwoExample()
    {
        var result = await DayOne.SolvePartTwoAsync(50, "day1_test.txt");
        Assert.Equal(6, result);
    }

    [Theory]
    [InlineData(99, 1, 0)]
    [InlineData(0, -1, 99)]
    [InlineData(50, 20, 70)]
    [InlineData(82, -30, 52)]
    [InlineData(50, 70, 20)]
    [InlineData(50, -55, 95)]
    [InlineData(50, 1000, 50)]
    public void GetNewPosition(int currentPosition, int num, int expectedPosition)
    {
        var result = DayOne.GetNewPosition(currentPosition, num);
        Assert.Equal(expectedPosition, result);
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(0, 100, 1)]
    [InlineData(0, -100, 1)]
    [InlineData(50, 20, 0)]
    [InlineData(82, -30, 0)]
    [InlineData(50, 70, 1)]
    [InlineData(50, -55, 1)]
    [InlineData(50, 200, 2)]
    [InlineData(50, -200, 2)]
    [InlineData(50, 1000, 10)]
    public void NumberZeroPasses(int currentPosition, int num, int expectedPasses)
    {
        var result = DayOne.GetNumberZeroPasses(currentPosition, num);
        Assert.Equal(expectedPasses, result);

    }
}