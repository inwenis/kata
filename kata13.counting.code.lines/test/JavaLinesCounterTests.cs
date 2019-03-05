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

        [Test]
        public void Count_EmptyLines_AreNotCountedAsCode()
        {
            string code = "" +
            "public class Hello {                                              " + "\n" +
            "    public static final void main(String[] args) {                " + "\n" +
            "        System.out.println(\"hello world\");                      " + "\n" +
            "    }                                                             " + "\n" +
            "}                                                                 " + "\n" +
            "                                                                  ";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Count_SingleLineBlockComments_AreNotCountedAsCode()
        {
            string code = "" +
            "/* this is a block comment */                                     " + "\n" +
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
        public void Count_BlockComments_AreNotCountedAsCode()
        {
            string code = "" +
            "/* this is a block comment                                        " + "\n" +
            "still a comment                                                   " + "\n" +
            "here is ends */                                                   " + "\n" +
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
        public void Count_CodeBetweenBlockComment_IsCountedAsCode()
        {
            string code = "" +
            "/* this is a block comment                                        " + "\n" +
            "still a comment                                                   " + "\n" +
            "here is ends */                                                   " + "\n" +
            "public class Hello {                                              " + "\n" +
            "/* another one */                                                 " + "\n" +
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
        public void Count_LineCommentInCommentBlock_IsNotSubtractedTwice()
        {
            string code = "" +
            "/* this is a block comment                                        " + "\n" +
            "//this line should not be subtracted twice                        " + "\n" +
            "here is ends */                                                   " + "\n" +
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
        public void Count_BlockCommentInSameLineAsCode_IsCountedAsLOC()
        {
            string code = "" +
            "public class Hello {                                              " + "\n" +
            "    public static final void main(String[] args) {                " + "\n" +
            "/* this line is still code */ int x;                              " + "\n" +
            "    }                                                             " + "\n" +
            "}                                                                 ";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Count_CodeBetweenBlockCommentsInSameLine_IsCountedAsLOC()
        {
            string code = "/* this line is still code */ int x; /* more */";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Count_InlineCommentInString_IsNotAComment()
        {
            string code = "String s = \"this no comment // asdfsafd \"; /* stil no comment\n" +
                          "still no comments end */                                         ";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Count_CodeLineSeparatedByBlockComments_AreCountedAreSeparateLOC()
        {
            string code = "int x = 0; /* comment \n" +
                          " more comments        \n" +
                          " */ int y = 1;          ";

            // act
            int result = JavaLinesCounter.Count(code);
            // assert
            Assert.AreEqual(2, result);
        }
    }
}