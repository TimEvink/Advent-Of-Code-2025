using Xunit;
using FluentAssertions;
using System;
using System.IO;
using System.Collections.Generic;
using aoc2025.src.Days;

namespace aoc2025.tests.Days;
public class Day05Tests {
    [Fact]
    public void GetBoundsTest() {
        var day = new Day05("testinput/day05/getboundsinput.txt");
        (long, long)[] bounds = [.. day.GetBounds()];
        (long, long)[] expected = new (long, long)[] { (3, 5), (7, 10) };
        bounds.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void GetIDsTest() {
        var day = new Day05("testinput/day05/getboundsinput.txt");
        long[] bounds = [.. day.GetIDs()];
        long[] expected = new long[]{ 10, 11 };
        bounds.Should().BeEquivalentTo(expected);
    } 
    [Fact]
    public void Example1Test() {
        var day = new Day05("testinput/day05/example.txt");
        Assert.Equal(3, day.SolvePart1());
    }

    public static IEnumerable<object[]> JoinRangesData1 =>
        new List<object[]>
        {
            new object[] { (1L, 10L), (3L, 11L), (1L, 11L) },
            new object[] { (5L, 7L), (2L, 6L), (2L, 7L) },
            new object[] { (-1L, 30L), (2L, 15L), (-1L, 30L) },
        };

    public static IEnumerable<object[]> JoinRangesData2 =>
    new List<object[]>
    {
            new object[] { (1L, 10L), (12L, 20L) },
            new object[] { (-3L, 10L), (21L, 30L)},
    };
    
    [Theory]
    [MemberData(nameof(JoinRangesData1))]
    public void JoinRangesTest1((long, long) range1, (long, long) range2, (long, long) expected) {
        Assert.Equal(expected, Day05.JoinRanges(range1, range2));
    }

    [Theory]
    [MemberData(nameof(JoinRangesData2))]
    public void JoinRangesTest2((long, long) range1, (long, long) range2) {
        Assert.Null(Day05.JoinRanges(range1, range2));
    }

    [Fact]
    public void Example2Test() {
        var day = new Day05("testinput/day05/example.txt");
        Assert.Equal(14L, day.SolvePart2());
    }
}
