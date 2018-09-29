using NUnit.Framework;
using test_string_vs_struct;

[TestFixture]
class MathTests
{
    [Test]
    [TestCase(10, 0, 1)]
    [TestCase(10, 1, 10)]
    [TestCase(10, 2, 100)]
    [TestCase(10, 3, 1000)]
    public void Test_Pow(int x, int y, int expected)
    {
        var pow = Math.Pow(x, y);
        Assert.AreEqual(expected, pow);
    }
}