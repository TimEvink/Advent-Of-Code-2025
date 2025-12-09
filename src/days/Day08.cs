using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using aoc2025.src.interfaces;
using aoc2025.src.utils;

namespace aoc2025.src.Days;
public class Day08 : IDay {
    private readonly string _inputPath;
    private readonly int _connectionnumber;
    public Day08(string inputPath = "") {
        _inputPath = inputPath;
        _connectionnumber = _inputPath == Path.Join("input", "Day08.txt") ? 1000 : 10;
    }

    public object SolvePart1() {
        var verticesinput = new List<Point3D<long>>();
        foreach (string line in File.ReadLines(_inputPath)) {
            string[] coordinates = line.Split(',');
            var point = new Point3D<long>(long.Parse(coordinates[0]), long.Parse(coordinates[1]), long.Parse(coordinates[2]));
            verticesinput.Add(point);
        }
        var pairs = new List<(Point3D<long>, Point3D<long>)>();
        for (int i = 0; i < verticesinput.Count; i++) {
            for (int j = i + 1; j < verticesinput.Count; j++) {
                pairs.Add((verticesinput[i], verticesinput[j]));
            }
        }
        var graph = new Graph<Point3D<long>>(verticesinput, pairs.OrderBy(Pair => (Pair.Item1 - Pair.Item2).AlgebraicNorm()).Take(_connectionnumber), true);
        var sizes = graph.Components().Select(l => l.Count).OrderDescending().Take(3).ToArray();
        return sizes[0] * sizes[1] * sizes[2];
    }
    public object SolvePart2() {
        var verticesinput = new List<Point3D<long>>();
        foreach (string line in File.ReadLines(_inputPath)) {
            string[] coordinates = line.Split(',');
            var point = new Point3D<long>(long.Parse(coordinates[0]), long.Parse(coordinates[1]), long.Parse(coordinates[2]));
            verticesinput.Add(point);
        }
        var pairs = new List<(Point3D<long>, Point3D<long>)>();
        for (int i = 0; i < verticesinput.Count; i++) {
            for (int j = i + 1; j < verticesinput.Count; j++) {
                pairs.Add((verticesinput[i], verticesinput[j]));
            }
        }
        var orderedpairs = pairs.OrderBy(Pair => (Pair.Item1 - Pair.Item2).AlgebraicNorm()).ToArray();
        //we do a bisection search on the connection number to zoom in on the precise cut off point of going from >1 components to being connected.
        int lower = 1;
        int upper = pairs.Count;
        //the loop invariant is as follows: for values of lower, the graph is disconnected, while for values of upper, it is connected.
        while (upper - lower > 1) {
            int middle = (upper + lower) / 2;
            var graph = new Graph<Point3D<long>>(verticesinput, orderedpairs.Take(middle), true);
            if (graph.Components().Count == 1) {
                upper = middle;
            }
            else {
                lower = middle;
            }
        }
        //when we have upper = lower + 1. The upper'th edge is the one that made the graph connected. Accounting for 0-based indexing we want index lower = upper - 1
        var pair = orderedpairs[lower];
        return pair.Item1.X * pair.Item2.X;
    }
}
