using System.IO;
using System.Linq;
using System.Text;

namespace aoc2025.src.Days;
public class Day03 : IDay {    
    private static long getMaxJoltage(string bank, int n) {
        if (n <= 0 || bank.Length < n) return 0;
        var sb = new StringBuilder(n);
        int index = -1;
        for (int i = 1; i <= n; i++) {
            char digit = bank[(index + 1)..^(n - i)].Max();
            index = bank.IndexOf(digit, index + 1);
            sb.Append(digit);
        }
        return long.Parse(sb.ToString());
    }

    public object SolvePart1() {
        return File.ReadLines("input/Day03.txt").Sum(line => getMaxJoltage(line, 2));
    }

    public object SolvePart2() {
        return File.ReadLines("input/Day03.txt").Sum(line => getMaxJoltage(line, 12));
    }
}
