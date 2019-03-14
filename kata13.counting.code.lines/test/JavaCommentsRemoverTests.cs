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
        Assert.AreEqual("\n\n\n\n\nint x;", result);
    }

    [Test]
    public void RemoveComments_LineCommentBetweenCode_IsRemoved()
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

    [Test]
    public void RemoveComments_LineCommentInString_IsNotRemoved()
    {
        // arrange
        string code = "String s = \"this is a string // still a string \";";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        string expected = "String s = \"this is a string // still a string \";";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void RemoveComments_LineCommentAfterStringWithTwoForwadSlashes_IsRemoved()
    {
        // arrange
        string code = "String s = \"this is a string // still a string \"; // to be removed";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        string expected = "String s = \"this is a string // still a string \"; ";
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void RemoveComments_MultiLineBlockComment_RemovesCommentButNewLinesStay()
    {
        // arrange
        string code = "int x; /* comment \n comment */ int y;";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("int x; \n int y;", result);
    }

    [Test]
    public void RemoveComments_MultipleLineComments_AreRemoved()
    {
        // arrange
        string code = "int x; //comment \n int y; //comment \n int x; //another one";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("int x; \n int y; \n int x; ", result);
    }

    [Test]
    public void RemoveComments_StringLookingAsBlockComments_AreNotRemoved()
    {
        // arrange
        string code = "String x = \"/*\" \n String y = \"*/\";";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("String x = \"/*\" \n String y = \"*/\";", result);
    }

    [Test]
    public void RemoveComments_QuotesInStrings_AreHandledCorrectly()
    {
        // arrange
        string code = "String x = \"some words \\\" more\";";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual(code, result);
    }

    [Test]
    public void RemoveComments_BlockCommentWithTwoForwardSlashes_IsRemoved()
    {
        // arrange
        string code = "/* block comment \n // block comment closing */";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("\n", result);
    }

    [Test]
    public void RemoveComments_ForwardSlashAndAsteriksInALineCommnet_IsNotABlockComment()
    {
        // arrange
        string code = "//line comment/* \nint x = 0;//line comment*/";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("\nint x = 0;", result);
    }

    [Test]
    public void RemoveComments_LineCommentWhichIsALineCommentAndTheSameIsNestedInABlockComment_IsHandledCorrectly()
    {
        // arrange
        string code = "//line comment*/\nint x = 0;/* //line comment*/";

        // act
        string result = JavaCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual("\nint x = 0;", result);
    }
}
