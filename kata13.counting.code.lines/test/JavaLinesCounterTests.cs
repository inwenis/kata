using NUnit.Framework;

namespace Tests
{
    public class JavaLinesCounterTests
    {
        [Test]
        public void Count_EmptyInput_Returns0()
        {
            // arrange
            // act
            int result = JavaLinesCounter.Count("");
            // assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Count_SingleLineOfCode_Returns1()
        {
            // act
            int result = JavaLinesCounter.Count("public interface Dave {}");
            // assert
            Assert.AreEqual(1, result);
        }
    }
}