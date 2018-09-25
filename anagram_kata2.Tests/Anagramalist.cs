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

    [Test]
    public void FindAllAnagrams_NonMachingWordInInputWithSameLength_Returns2WordsAnagram()
    {
        string[] input = new []{"word", "drow", "xxxx"};

        var result = Anagramalist.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow"}, result);
    }

    [Test]
    public void FindAllAnagrams_2PossibleAnagramsInInput_Returns2Anagrams()
    {
        string[] input = new []{"word", "drow", "dog", "god"};

        var result = Anagramalist.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow", "dog god"}, result);
    }

    [Test]
    public void FindAllAnagrams_WordsHasSameLengthButThereIsNoAnagrams_ReturnsEmptyArray()
    {
        string[] input = new []{"word", "yyyy", "xxxx"};

        var result = Anagramalist.FindAllAnagrams(input);

        Assert.IsEmpty(result);
    }
}
