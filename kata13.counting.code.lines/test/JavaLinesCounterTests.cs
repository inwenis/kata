using NUnit.Framework;

namespace Tests
{
    public class JavaLinesCounterTests
    {
        [Test]
        public void Count_EmptyInput_Returns0LinesOfCode()
        {
            // arrange
            // act
            int result = JavaLinesCounter.Count("");
            // assert
            Assert.AreEqual(0, result);
        }
    }
}