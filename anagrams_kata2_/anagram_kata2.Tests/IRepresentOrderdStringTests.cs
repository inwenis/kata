using NUnit.Framework;
using test_string_vs_struct;

[TestFixture]
class IRepresentOrderdStringTests
{
    [Test]
    [TestCase("Z",                          "000000000000000000000000000000000100000000000000000000000000")]
    [TestCase("ABCD",                       "000000000000000000000000000000000000000000000000000000001111")]
    //                                                                        ZYXWVUT SRQPONMLKJIHGFEDCBA
    [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "000000000000000000000000000000000111111101111111111111111111")]
    [TestCase("abcdefghijklmnopqrstuvwxyz", "111111111111111111110111111000000000000000000000000000000000")]
    [TestCase("SSSSSSSSST",                 "000000000000000000000000000000000000000109000000000000000000")]
    [TestCase("Belorussian's",              "000001031001101001000010001000001000000000000000000000000010")]
    [TestCase("Byelorussians",              "010001031001101001000010001000000000000000000000000000000010")]
    [TestCase("Hloise's",                   "000000020001001001000010000000001000000000000000000010000000")]
    [TestCase("H?loise's",                  "000000020001001001000010000000002000000000000000000010000000")]
    [TestCase("H�loise's",                  "000000020001001001000010000000011000000000000000000010000000")]
    public void Test(string word, string expected)
    {
        var representOrderdString = IRepresentOrderdString.FromString(word);
        Assert.AreEqual(expected, representOrderdString.ToString());
    }
}
