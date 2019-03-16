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
}