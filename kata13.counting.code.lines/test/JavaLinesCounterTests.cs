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

        [Test]
        public void Count_MultipleLinesOfCode_ReturnsLinesCount()
        {
            string code = "" +
            "public class Hello {                                              " + "\n" +
            "    public static final void main(String[] args) {                " + "\n" +
            "        System.out.println(\"hello world\");                      " + "\n" +
            "    }                                                             " + "\n" +
            "}                                                                 ";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Count_CodeWithWholeLineComment_ReturnsLinesCount()
        {
            string code = "" +
            "public class Hello {                                              " + "\n" +
            "    public static final void main(String[] args) {                " + "\n" +
            "    // this is a simple comment                                   " + "\n" +
            "        System.out.println(\"hello world\");                      " + "\n" +
            "    }                                                             " + "\n" +
            "}                                                                 ";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Count_CodeLineWtihCodeAndComment_LineIsCountedAsCode()
        {
            string code = "" +
            "public class Hello {                                              " + "\n" +
            "    public static final void main(String[] args) {                " + "\n" +
            "        System.out.println(\"hello world\"); // comment           " + "\n" +
            "    }                                                             " + "\n" +
            "}                                                                 ";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(5, result);
        }
    }
}