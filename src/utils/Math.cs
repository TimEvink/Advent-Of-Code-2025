using System;

namespace aoc2025.src.utils;

public static class Mathutils {
    public static int TrueMod(int n, int m) => ((n % m) + Math.Abs(m)) % Math.Abs(m);

    public static int TrueDiv(int n, int m) => (n - TrueMod(n, m)) / m;
}