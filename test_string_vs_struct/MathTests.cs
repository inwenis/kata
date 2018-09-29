using NUnit.Framework;
using test_string_vs_struct;

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
    //[TestCase(10, 20, 100000000000000000000UL)]
    public void Test_Pow(int x, int y, ulong expected)
    {
        var pow = Math.Pow(x, y);
        Assert.AreEqual(expected, pow);
    }
}