using aoc2025.src;
using aoc2025.src.interfaces;
using System;
using System.Numerics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace aoc2025.src.utils;
public class Point3D<T> : IPoint3D<T>, IEquatable<Point3D<T>>
    where T : INumber<T>{
    required public T X { get; set; }
    required public T Y { get; set; }
    required public T Z { get; set; }

    [SetsRequiredMembers]
    public Point3D((T, T, T) point) {
        X = point.Item1;
        Y = point.Item2;
        Z = point.Item3;
    }

    [SetsRequiredMembers]
    public Point3D(T x, T y, T z) {
        X = x;
        Y = y;
        Z = z;
    }

    public static Point3D<T> operator +(Point3D<T> P) {
        return new(P.X, P.Y, P.Z);
    }

    public static Point3D<T> operator -(Point3D<T> P) {
        return new(-P.X, -P.Y, -P.Z);
    }

    public static Point3D<T> operator +(Point3D<T> P, Point3D<T> Q) {
        return new(P.X + Q.X, P.Y + Q.Y, P.Z + Q.Z);
    }

    public static Point3D<T> operator -(Point3D<T> P, Point3D<T> Q) {
        return new(P.X - Q.X, P.Y - Q.Y, P.Z - Q.Z);
    }

    public static Point3D<T> operator *(T alpha, Point3D<T> P) {
        return new(alpha * P.X, alpha * P.Y, alpha * P.Z);
    }

    public static Point3D<T> operator *(Point3D<T> P, T alpha) {
        return new(alpha * P.X, alpha * P.Y, alpha * P.Z);
    }

    public static Point3D<T> Zero {
        get { return new(T.Zero, T.Zero, T.Zero); }
    }

    public bool Equals(Point3D<T>? other)
    {
        if (other is null) return false;
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point3D<T> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

	public override string ToString() {
        return $"({X}, {Y}, {Z})";
	}

    public T AlgebraicNorm() {
        return X * X + Y * Y + Z * Z;
    }
}
