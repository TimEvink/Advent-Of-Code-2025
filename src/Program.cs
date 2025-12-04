using System;
using System.IO;
using System.Linq;
using System.Reflection;

using aoc2025.src.interfaces;

static class Program {
    static void Main(string[] args) {
        int day;
        if (args.Length == 0) {
            Console.WriteLine("Defaulting to solution for day 1. For other days pass day number as optional parameter.");
            day = 1;
        }
        else if (int.TryParse(args[0], out var d)) {
            day = d;
        }
        else {
            Console.WriteLine($"Invalid day argument '{args[0]}', defaulting to solution for day 1.");
            day = 1;
        }
        string className = $"Day{day:D2}";
        Type? dayType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == className && t.Namespace == "aoc2025.src.Days");
        if (dayType == null) {
            Console.WriteLine($"Day {day} not found.");
            return;
        }
        string inputPath = Path.Combine("input", $"{className}.txt");
        IDay dayInstance = (IDay) Activator.CreateInstance(dayType, new object?[] { inputPath })!;
        Console.WriteLine($"Running day {day}, part 1...");
        Console.WriteLine($"Solution: {dayInstance.SolvePart1()}");
        Console.WriteLine($"Running day {day}, part 2...");
        Console.WriteLine($"Solution: {dayInstance.SolvePart2()}");
    }
}
