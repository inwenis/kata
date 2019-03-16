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
}