using NUnit.Framework;

public class JavaNoRegexCommentsRemoverTests
{
    [Test]
    public void RemoveComments_EmptyString_ReturnEmptyString()
    {
        // arrange

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments("");

        // assert
        Assert.AreEqual("", result);
    }

    [Test]
    public void RemoveComments_CodeWithNoComments_DoesNothing()
    {
        // arrange
        string code = "int x = 0;";

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual(code, result);
    }

    [Test]
    public void RemoveComments_CodeWithOnlyComment_RemovesEverything()
    {
        // arrange
        string code = "//this is a comment";

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("", result);
    }

    [Test]
    public void RemoveComments_CodeWithLineCommentAtEnd_LineCommentIsRemoved()
    {
        // arrange
        string code = "int x = 0; //this is a comment";

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("int x = 0; ", result);
    }

    [Test]
    public void RemoveComments_CodeWithLineCommentBeforeCode_LineCommentIsRemoved()
    {
        // arrange
        string code = "//this is a comment\n" +
                      "int x = 0;";

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("\nint x = 0;", result);
    }

    [Test]
    public void RemoveComments_CodeWithLineCommentBeforeCodeWithCRLF_LineCommentIsRemoved()
    {
        // arrange
        string code = "//this is a comment\r\n" +
                      "int x = 0;";

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("\r\nint x = 0;", result);
    }
}