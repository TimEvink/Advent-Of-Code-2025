using System;
using System.Linq;
using System.Collections.Generic;

namespace aoc2025.src.utils;
public class Graph<T> where T : IEquatable<T> {
    private HashSet<T> _vertices;
    private Dictionary<T, HashSet<T>> _adjacency;

    public IReadOnlySet<T> Vertices { get => _vertices; }

    public Graph(IEnumerable<T> vertices, IEnumerable<(T, T)> edges, bool undirected = false) {
        _vertices = vertices.ToHashSet();
        _adjacency = new Dictionary<T, HashSet<T>>();
        foreach (var vertex in vertices) {
            _adjacency[vertex] = new HashSet<T>();
        }
        foreach (var (v, w) in edges) {
            _adjacency[v].Add(w);
            if (undirected) _adjacency[w].Add(v);
        }
    }

    //reconstructs vertices from edges. Cannot produce isolated vertices.
    public Graph(IEnumerable<(T, T)> edges, bool undirected = false) {
        _vertices = new HashSet<T>();
        _adjacency = new Dictionary<T, HashSet<T>>();
        foreach (var (v, w) in edges) {
            _vertices.Add(v);
            _vertices.Add(w);
            if (!_adjacency.ContainsKey(v)) _adjacency[v] = new HashSet<T>();
            if (!_adjacency.ContainsKey(w)) _adjacency[w] = new HashSet<T>();
            _adjacency[v].Add(w);
            if (undirected) _adjacency[w].Add(v);
        }
    }

    //gets outgoing vertices. So Neighbors(v) is the set of those vertices such that we have an edge v -> w
    public IReadOnlySet<T> Neighbors(T vertex) => _adjacency[vertex];

    public List<HashSet<T>> Components() {
        var unvisited = new HashSet<T>(_vertices);
        var componentList = new List<HashSet<T>>();
        while (unvisited.Count != 0) {
            var component = new HashSet<T>();
            var stack = new Stack<T>(new[] { unvisited.First() });
            while (stack.Count != 0) {
                T vertex = stack.Pop();
                component.Add(vertex);
                unvisited.Remove(vertex);
                foreach (T neighbor in _adjacency[vertex]) {
                    if (unvisited.Contains(neighbor)) stack.Push(neighbor);
                }
            }
            componentList.Add(component);
        }
        return componentList;
    }
}