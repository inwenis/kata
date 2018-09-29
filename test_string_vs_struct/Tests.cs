using System;
using System.Linq;
using NUnit.Framework;
using test_string_vs_struct;

[TestFixture]
class IRepresentOrderdStringTests
{
    [Test]
    public void ABCD()
    {
        var representOrderdString = IRepresentOrderdString.FromString("ABCD");
        Assert.AreEqual("000000000000000000000000000000000000000000000000000000001111", representOrderdString.ToString());
    }

    [Test]
    public void Z()
    {
        var representOrderdString = IRepresentOrderdString.FromString("Z");
        Assert.AreEqual("000000000000000000000000000000000100000000000000000000000000", representOrderdString.ToString());
    }

    [Test]
    public void SSSSSSSSST()
    {
        var representOrderdString = IRepresentOrderdString.FromString("SSSSSSSSST");
        Assert.AreEqual("000000000000000000000000000000000000000109000000000000000000", representOrderdString.ToString());
    }

    [Test]
    public void ABCDEFGHIJKLMNOPQRSTUVWXYZ()
    {
        var representOrderdString = IRepresentOrderdString.FromString("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        //                                                ZYXWVUT SRQPONMLKJIHGFEDCBA
        Assert.AreEqual("000000000000000000000000000000000111111101111111111111111111", representOrderdString.ToString());
    }

    [Test]
    public void ABCDEFGHIJKLMNOPQRSTUVWXYZ_lower()
    {
        var representOrderdString = IRepresentOrderdString.FromString("abcdefghijklmnopqrstuvwxyz");
        //               ZYXWVUTSRQPONMLKJIHG FEDCBA
        Assert.AreEqual("111111111111111111110111111000000000000000000000000000000000", representOrderdString.ToString());
    }
}
