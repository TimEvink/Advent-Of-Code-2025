using System.Numerics;

namespace aoc2025.src.interfaces;
public interface IPoint3D<T> where T : INumber<T> {
    T X { get; set; }
    T Y { get; set; }
    T Z { get; set; }
}