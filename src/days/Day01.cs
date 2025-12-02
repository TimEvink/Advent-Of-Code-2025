using System;
using System.IO;
using aoc2025.src.utils;

namespace aoc2025.src.Days;
public static class Day01 {
    public static void Part1() {
        int counter = 0;
        int position = 50;
        foreach (string line in File.ReadLines("input/Day01.txt")) {
            int sign = line[0] == 'R' ? 1 : -1;
            int increment = int.Parse(line[1..]);
            position += sign * increment;
            position %= 100;
            if (position == 0) {
                counter += 1;
            }
        }
        Console.WriteLine($"Solution: {counter}");
    }
    public static void Part2() {
        Console.WriteLine("Solution: wip");
    }
}
