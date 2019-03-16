using NUnit.Framework;

public class JavaNoRegexCommentsRemoverTests
{
    [TestCase("", "", "EmptyString_ReturnEmptyString")]
    [TestCase("int x = 0", "int x = 0", "CodeWithNoComments_DoesNothing")]
    [TestCase("//this is a comment", "", "CodeWithOnlyComment_RemovesEverything")]
    [TestCase("int x = 0; //this is a comment", "int x = 0; ", "CodeWithLineCommentAtEnd_LineCommentIsRemoved")]
    [TestCase("//this is a comment\nint x = 0;", "\nint x = 0;", "CodeWithLineCommentBeforeCode_LineCommentIsRemoved")]
    [TestCase("//this is a comment\r\nint x = 0;", "\r\nint x = 0;", "CodeWithLineCommentBeforeCodeWithCRLF_LineCommentIsRemoved")]
    [TestCase("//this is a comment\r", "", "CommentEndingWithOnlyCR_CommentIsRemoved")]
    [TestCase("/", "/", "SingleForwardSlash_IsNotRemoved")]
    [TestCase("/* comment */", "", "BlockComment_IsRemoved")]
    [TestCase("/* comment */int x = 0;", "int x = 0;", "CodeAfterBlockComment_OnlyCommentIsRemoved")]
    [TestCase("/* //comment */int x = 0;", "int x = 0;", "LineCommentNestedInBlockComment_CommentsAreRemoved")]
    [TestCase("//line/*this is not block comment\nint x = 0;", "\nint x = 0;", "BlockCommentNestedInLineComment_CommentsAreRemoved")]
    [TestCase("/*\n\n*/", "\n\n", "MultiLineBlockComment_NewLineCharactersAreNotRemoved")]
    [TestCase("/*\r\n \n \r*/", "\r\n\n\r", "MultiLineBlockCommentWithDifferentLineEndings_NewLineCharactersAreNotRemoved")]
    [TestCase("String x=\"//\";", "String x=\"//\";", "TwoForwardSlashesInString_AreNotComments")]
    public void Test(string code, string expected, string message)
    {
        // arrange

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual(expected, result, message);
    }
}
