using Xunit;
using aoc2025.src.Days;

namespace aoc2025.tests.Days;
public class Day08Tests {
    [Fact]
    public void Example1Test() {
        var day = new Day08("testinput/day08/example.txt");
        Assert.Equal(40, day.SolvePart1());
    }

    [Fact]
    public void Example2Test() {
        var day = new Day08("testinput/day08/example.txt");
        Assert.Equal(25272L, day.SolvePart2());
    }
}
