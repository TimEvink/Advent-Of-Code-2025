using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using aoc2025.src.interfaces;

namespace aoc2025.src.Days;
public class Day06 : IDay {
    private readonly string _inputPath;
    public Day06(string inputPath = "") {
        _inputPath = inputPath;
    }

    private static readonly Dictionary<char, Func<long, long, long>> operations = new Dictionary<char, Func<long, long, long>> {
        ['+'] = (a, b) => a + b,
        ['*'] = (a, b) => a * b
    };

    public string[][] ParseInput() {
        return File.ReadLines(_inputPath).Select(line => Regex.Split(line.Trim(), @"\s+")).ToArray();
    }

    public string[] ParseInputRaw() {
        return File.ReadAllLines(_inputPath);
    }

    public object SolvePart1() {
        var input = ParseInput();
        int rownumber = input.Length;
        char[] operationchars = input[rownumber - 1].Select(s => s[0]).ToArray();
        long counter = 0;
        for (int i = 0; i < input[0].Length; i++) {
            var iterator = Enumerable.Range(0, input.Length - 1).Select(j => long.Parse(input[j][i]));
            counter += iterator.Aggregate(operations[operationchars[i]]);
        }
        return counter;
    }

    public long? CephalopodNumber(string[] input, int index) {
        IEnumerable<char> chars = Enumerable.Range(0, input.Length - 1)
            .Select(i => input[i][index])
            .Where(c => c !=' ');
        return long.TryParse(new string(chars.ToArray()), out var result) ? result: null;
    }

    public object SolvePart2() {
        var input = ParseInputRaw();
        int rownumber = input.Length;
        long totalcount = 0;
        char operation = input[rownumber - 1][0];
        List<long> numbers = new();
        for (int index = 0; index < input[0].Length; index++) {
            long? number = CephalopodNumber(input, index);
            if (number == null) {
                totalcount += numbers.Aggregate(operations[operation]);
                numbers.Clear();
                continue;
            }
            char potentialnewoperation = input[rownumber - 1][index];
            if (potentialnewoperation != ' ') operation = potentialnewoperation;
            numbers.Add(number.Value);
        }
        totalcount += numbers.Aggregate(operations[operation]);
        return totalcount;
    }
}
