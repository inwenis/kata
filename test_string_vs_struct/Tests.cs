using NUnit.Framework;
using test_string_vs_struct;

[TestFixture]
class Tests
{
    [Test]
    public void DoTest()
    {
        var b = IRepresentOrderdString.FromString("aabhiinott") == IRepresentOrderdString.FromString("acehnrt");

        Assert.IsFalse(b);
    }
}
