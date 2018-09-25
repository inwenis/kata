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

    [Test]
    public void FindAllAnagrams_OnePossibleAnagramInInput_ReturnsAnagram()
    {
        string[] input = new []{"word", "drow"};

        var result = Anagramalist.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow"}, result);
    }

    [Test]
    public void FindAllAnagrams_3WordsInInputWithSameLetters_Returns3WordsAnagram()
    {
        string[] input = new []{"word", "drow", "drwo"};

        var result = Anagramalist.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow drwo"}, result);
    }

    [Test]
    public void FindAllAnagrams_3WordsInInputButOnlyTwoHaveSameLetters_Returns2WordsAnagram()
    {
        string[] input = new []{"word", "drow", "x"};

        var result = Anagramalist.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow"}, result);
    }
}
