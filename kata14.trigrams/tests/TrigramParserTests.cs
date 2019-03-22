using System.Collections.Generic;
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
}