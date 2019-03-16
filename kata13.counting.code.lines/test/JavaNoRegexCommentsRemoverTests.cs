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
    public void Test(string code, string expected, string message)
    {
        // arrange

        // act
        string result = JavaNoRegexCommentsRemover.RemoveComments(code);

        // assert
        Assert.AreEqual(expected, result, message);
    }
}
