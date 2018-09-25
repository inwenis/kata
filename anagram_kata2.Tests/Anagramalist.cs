using anagram_kata2;
using NUnit.Framework;

[TestFixture]
public class AnagramalistTests
{
    [Test]
    public void FindAllAnagrams_NoWords_ReturnsEmptyResult()
    {

        var result = Anagramalist.FindAllAnagrams(new string[0]);

        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }
}
