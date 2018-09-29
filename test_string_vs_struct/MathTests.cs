using NUnit.Framework;
using test_string_vs_struct;

[TestFixture]
class MathTests
{
    [Test]
    public void Test1()
    {
        var pow = Math.Pow(10, 1);
        Assert.AreEqual(10, pow);
    }
}