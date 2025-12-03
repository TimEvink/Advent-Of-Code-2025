using System.Text;

namespace aoc2025.src.utils;

public static class StringUtils {
    public static string Repeat(this string s, int count)
{
    if (count <= 0) return "";
    if (count == 1) return s;
    var sb = new StringBuilder(s.Length * count);
    for (int i = 0; i < count; i++) {
        sb.Append(s);
    }
    return sb.ToString();
}
}