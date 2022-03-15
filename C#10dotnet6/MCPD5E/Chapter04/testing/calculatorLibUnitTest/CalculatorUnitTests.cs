using Xunit;
using Hzx;

namespace CalculatorLibUnitTest;

public class CalculatorUnitTests
{
    [Fact]
    public void Test1()
    {
        // arrange
        double a = 2;
        double b = 2;
        double expected = 4;
        var calc = new Calculator();

        // act
        double actual = calc.Add(a, b);
        
        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test2()
    {
        double a = 2;
        double b = 3;
        double expected = 5;
        var calc = new Calculator();

        double actual = calc.Add(a, b);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test3()
    {
        double a = 2;
        double b = 2;
        double expected = 4;
        var calc = new Calculator();

        double actual = calc.Multiple(a, b);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Test4()
    {
        double a = 2;
        double b = 3;
        double expected = 6;
        var calc = new Calculator();

        double actual = calc.Multiple(a, b);
        Assert.Equal(expected, actual);
    }
}