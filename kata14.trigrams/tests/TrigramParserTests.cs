using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void Parse_EmptyInput_ReturnsEmptyDictionary()
    {
        // arrange

        // act
        Dictionary<(string, string), string> result = TrigramParser.Parse("");

        // assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void Parse_3WordsSentence_ReturnsDictionaryWithSingleEntry()
    {
        // arrange

        // act
        Dictionary<(string, string), string> result = TrigramParser.Parse("dummyA dummyB dummyC");

        // assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(("dummyA", "dummyB"), result.ElementAt(0).Key);
        Assert.AreEqual("dummyC", result.ElementAt(0).Value);
    }

    [Test]
    public void Parse_4WordsSentence_ReturnsDictionaryWithTwoEntries()
    {
        // arrange

        // act
        Dictionary<(string, string), string> result = TrigramParser.Parse("dummyA dummyB dummyC dummyD");

        // assert
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual(("dummyA", "dummyB"), result.ElementAt(0).Key);
        Assert.AreEqual("dummyC", result.ElementAt(0).Value);
        Assert.AreEqual(("dummyB", "dummyC"), result.ElementAt(1).Key);
        Assert.AreEqual("dummyD", result.ElementAt(1).Value);
    }
}