using NUnit.Framework;

public class JavaCommentsRemoverTests
{
    [Test]
    public void RemoveComments_EmptyInput_ReturnEmptyString()
    {
        // arrange

        // act
        string result = JavaCommentsRemover.RemoveComments("");

        // assert
        Assert.AreEqual("", result);
    }

    [Test]
    public void RemoveComments_LineComment_IsRemoved()
    {
        // arrange
        string input = "int x;// comment";

        // act
        string result = JavaCommentsRemover.RemoveComments(input);

        // assert
        Assert.AreEqual("int x;", result);
    }

    [Test]
    public void RemoveComments_OneLineBlockComment_IsRemoved()
    {
        // arrange
        string input = "int x;/*block comment*/";

        // act
        string result = JavaCommentsRemover.RemoveComments(input);

        // assert
        Assert.AreEqual("int x;", result);
    }

    [Test]
    public void RemoveComments_CodeBetweenOneLineBlockComment_IsNotRemoved()
    {
        // arrange
        string input = "/*comment*/int x;/*block comment*/";

        // act
        string result = JavaCommentsRemover.RemoveComments(input);

        // assert
        Assert.AreEqual("int x;", result);
    }

    [Test]
    public void RemoveComments_MultiLineBlockComments_AreRemoved()
    {
        // arrange
        string input = "/*this\ncomment\nhas\nmultiple\nlines*/\nint x;";

        // act
        string result = JavaCommentsRemover.RemoveComments(input);

        // assert
        Assert.AreEqual("\nint x;", result);
    }

    [Test]
    public void RemoveComments_MultiLineBlockComments_AreRemovedXX()
    {
        // arrange
        string code = "" +
            " int x;     \n" +
            " // comment \n" +
            " int y;     \n";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        string expected = "" +
            " int x;     \n" +
            " \n" +
            " int y;     \n";
        Assert.AreEqual(expected, result);
    }
}
