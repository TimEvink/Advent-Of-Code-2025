using System.IO;

namespace aoc2025.src.Days;
public class Day01 : IDay {
    public object SolvePart1() {
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
        return counter;
    }
    public object SolvePart2() {
        return "wip";
    }
}
