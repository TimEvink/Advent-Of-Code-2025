param(
    [Parameter(Mandatory=$true)]
    [int]$Day
)

$dayPadded = $Day.ToString("00")

# 1. Solver template
$dayFile = "src/days/Day${dayPadded}.cs"
$dayClass = @"
using aoc2025.src.interfaces;

namespace aoc2025.src.Days;
public class Day${dayPadded} : IDay {
    private readonly string _inputPath;
    public Day${dayPadded}(string inputPath = "") {
        _inputPath = inputPath;
    }

    public object SolvePart1() {
        return 0;
    }
    public object SolvePart2() {
        return 0;
    }
}
"@
Set-Content -Path $dayFile -Value $dayClass -Encoding UTF8
Write-Host "Created $dayFile"

# 2. Empty input.txt
$inputtxt = "input/Day${dayPadded}.txt"
New-Item -ItemType File -Path $inputtxt | Out-Null
Write-Host "Created $inputtxt"

# 3. Test template
$testFile = "tests/days/Day${dayPadded}Tests.cs"
$testClass = @"
using Xunit;
using aoc2025.src.Days;

namespace aoc2025.tests.Days;
public class Day${dayPadded}Tests {
    [Fact]
    public void Example1Test() {
        var day = new Day${dayPadded}("testinput/day${dayPadded}/example.txt");
        Assert.Equal(0, day.SolvePart1());
    }

    [Fact]
    public void Example2Test() {
        var day = new Day${dayPadded}("testinput/day${dayPadded}/example.txt");
        Assert.Equal(0, day.SolvePart2());
    }
}
"@
Set-Content -Path $testFile -Value $testClass -Encoding UTF8
Write-Host "Created $testFile"

# 4. Testinput txt file
New-Item -ItemType Directory -Path "tests/testinput/day${dayPadded}" | Out-Null
New-Item -ItemType File -Path "tests/testinput/day${dayPadded}/example.txt" | Out-Null
Write-Host "Created tests/testinput/day${dayPadded}/example.txt"
