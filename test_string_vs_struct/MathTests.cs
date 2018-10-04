using System;
using NUnit.Framework;
using Math = test_string_vs_struct.Math;

[TestFixture]
class MathTests
{
    [Test]
    [TestCase(10, 0, 1UL)]
    [TestCase(10, 1, 10UL)]
    [TestCase(10, 2, 100UL)]
    [TestCase(10, 3, 1000UL)]
    [TestCase(10, 10, 10000000000UL)]
    [TestCase(10, 15, 1000000000000000UL)]
    [TestCase(10, 18, 1000000000000000000UL)]
    [TestCase(10, 19, 10000000000000000000UL)]
    //[TestCase(10, 20, 100000000000000000000UL)] // this number is too big for a ulong
    public void Test_Pow(int x, int y, ulong expected)
    {
        var pow = Math.Pow(x, y);
        Assert.AreEqual(expected, pow);
    }

    [Test]
    public void Test2()
    {
        var big1 = Math.Pow(10, 18);
        var big2 = Math.Pow(10, 18);
        Console.WriteLine(big1);
        Console.WriteLine(big2);
        Console.WriteLine(big1 + big2);
    }
}