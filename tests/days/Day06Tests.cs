using Xunit;
using aoc2025.src.Days;

namespace aoc2025.tests.Days;
public class Day06Tests {
    [Fact]
    public void ParseInputTest() {
        var day = new Day06("testinput/day06/parseinputtest.txt");
        Assert.Equal(new[] {
            new string[] {"123", "328", "51"},
            new string[] {"45", "64", "387"},
            new string[] {"*", "+", "*"}
        }, day.ParseInput());
    }
    [Fact]
    public void Example1Test() {
        var day = new Day06("testinput/day06/example.txt");
        Assert.Equal(4277556L, day.SolvePart1());
    }

    [Theory]
    [InlineData(0, 1)]
    [InlineData(1, 24)]
    [InlineData(2, 356)]
    [InlineData(4, 369)]
    [InlineData(6, 8)]
    public void CephalopodNumberTest(int index, long expected) {
        var day = new Day06("testinput/day06/example.txt");
        var input = day.ParseInputRaw();
        Assert.Equal(expected, day.CephalopodNumber(input, index));
    }

    [Fact]
    public void Example2Test() {
        var day = new Day06("testinput/day06/example.txt");
        Assert.Equal(3263827L, day.SolvePart2());
    }
}