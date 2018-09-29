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

    [Test]
    public void Byelorussians()
    {
        var representOrderdString = IRepresentOrderdString.FromString("Byelorussians");
        //               ZYXWVUTSRQPONMLKJIHG FEDCBA
        Assert.AreEqual("010001031001101001000010001000000000000000000000000000000010", representOrderdString.ToString());
    }

    [Test]
    [TestCase("Belorussian's", "000001031001101001000010001000001000000000000000000000000010")]
    [TestCase("Hloise's",  "000000020001001001000010000000001000000000000000000010000000")]
    [TestCase("H?loise's", "000000020001001001000010000000002000000000000000000010000000")]
    public void Belorussian_s(string word, string expected)
    {
        var s = new string("H?loise's".OrderByDescending(x => x).ToArray());
        Console.WriteLine(s);
        var representOrderdString = IRepresentOrderdString.FromString(word);
        Assert.AreEqual(expected, representOrderdString.ToString());
    }
}
