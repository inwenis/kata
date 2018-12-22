using NUnit.Framework;
using kata02.karate.chop;

[TestFixture]
public class ChopTests
{
    [Test]
    [TestCase(-1, 3, new int []{})]
    [TestCase(-1, 3, new int []{1})]
    [TestCase(0,  1, new int []{1})]
    //
    [TestCase(0,  1, new int []{1, 3, 5})]
    [TestCase(1,  3, new int []{1, 3, 5})]
    [TestCase(2,  5, new int []{1, 3, 5})]
    [TestCase(-1, 0, new int []{1, 3, 5})]
    [TestCase(-1, 2, new int []{1, 3, 5})]
    [TestCase(-1, 4, new int []{1, 3, 5})]
    [TestCase(-1, 6, new int []{1, 3, 5})]
    //
    [TestCase(0,  1, new int []{1, 3, 5, 7})]
    [TestCase(1,  3, new int []{1, 3, 5, 7})]
    [TestCase(2,  5, new int []{1, 3, 5, 7})]
    [TestCase(3,  7, new int []{1, 3, 5, 7})]
    [TestCase(-1, 0, new int []{1, 3, 5, 7})]
    [TestCase(-1, 2, new int []{1, 3, 5, 7})]
    [TestCase(-1, 4, new int []{1, 3, 5, 7})]
    [TestCase(-1, 6, new int []{1, 3, 5, 7})]
    [TestCase(-1, 8, new int []{1, 3, 5, 7})]
    public static void Test_Chop(int expected, int searchFor, int[] array)
    {
        Assert.AreEqual(expected, Program.ChopIterative(searchFor, array));
        Assert.AreEqual(expected, Program.ChopRec(searchFor, array));
        Assert.AreEqual(expected, Program.ChopRec2(searchFor, array));
        Assert.AreEqual(expected, Program.ChopUnsafe(searchFor, array));
    }
}