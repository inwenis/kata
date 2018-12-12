using kata.sortingitout;
using NUnit.Framework;

[TestFixture]
class CharacterSorterTests
{
    [Test]
    public static void Sort_EmptyString_ReturnsEmptyString()
    {
        // arrange

        // act
        var result = CharacterSorter.Sort("");

        // assert
        Assert.AreEqual("", result);
    }

    [Test]
    public static void Sort_SortedText_ReturnsInput()
    {
        // arrange

        // act
        var result = CharacterSorter.Sort("aaabbb");

        // assert
        Assert.AreEqual("aaabbb", result);
    }

    [Test]
    public static void Sort_UnsortedText_ReturnsSortedText()
    {
        // act
        var result = CharacterSorter.Sort("bbbaaa");

        // assert
        Assert.AreEqual("aaabbb", result);
    }

    [Test]
    public static void Sort_TextWithPunctation_IgnoresPunctationAndReturnsSortedText()
    {
        // act
        var result = CharacterSorter.Sort("bbb.a a,a!");

        // assert
        Assert.AreEqual("aaabbb", result);
    }
}
