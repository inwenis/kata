using System.Linq;
using anagram_kata2;
using NUnit.Framework;

[TestFixture]
public class AnagramalistTests
{
    private IAnagramalist _sut;

    [SetUp]
    public void CreateSut()
    {
        _sut = new AnagramalistLinq();
    }

    [Test]
    public void FindAllAnagrams_NoWords_ReturnsEmptyResult()
    {
        var result = _sut.FindAllAnagrams(new string[0]);

        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
    }

    [Test]
    public void FindAllAnagrams_OnePossibleAnagramInInput_ReturnsAnagram()
    {
        string[] input = new []{"word", "drow"};

        var result = _sut.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow"}, result);
    }

    [Test]
    public void FindAllAnagrams_3WordsInInputWithSameLetters_Returns3WordsAnagram()
    {
        string[] input = new []{"word", "drow", "drwo"};

        var result = _sut.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow drwo"}, result);
    }

    [Test]
    public void FindAllAnagrams_3WordsInInputButOnlyTwoHaveSameLetters_Returns2WordsAnagram()
    {
        string[] input = new []{"word", "drow", "x"};

        var result = _sut.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow"}, result);
    }

    [Test]
    public void FindAllAnagrams_NonMachingWordInInputWithSameLength_Returns2WordsAnagram()
    {
        string[] input = new []{"word", "drow", "xxxx"};

        var result = _sut.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow"}, result);
    }

    [Test]
    public void FindAllAnagrams_2PossibleAnagramsInInput_Returns2Anagrams()
    {
        string[] input = new []{"word", "drow", "dog", "god"};

        var result = _sut.FindAllAnagrams(input);

        Assert.IsTrue(result.Contains("word drow"));
        Assert.IsTrue(result.Contains("dog god"));
    }

    [Test]
    public void FindAllAnagrams_WordsHasSameLengthButThereIsNoAnagrams_ReturnsEmptyArray()
    {
        string[] input = new []{"word", "yyyy", "xxxx"};

        var result = _sut.FindAllAnagrams(input);

        Assert.IsEmpty(result);
    }

    [Test]
    public void FindAllAnagrams_FirstWordHasSameLengthButHasDifferentLetters_AnagramIsReturnedAnyway()
    {
        string[] input = new []{"xxxx", "word", "drow"};

        var result = _sut.FindAllAnagrams(input);

        CollectionAssert.AreEqual(new []{"word drow"}, result);
    }
}
