using NUnit.Framework;

[TestFixture]
public class GameTests
{
    Game sut;

    [SetUp]
    public void Init()
    {
        sut = new Game();
    }

    [Test]
    public void when_all_rolls_have_0_pins_down_score_is_0()
    {
        RollMany(20, 0);
        Assert.AreEqual(0, sut.Score());
    }

    [Test]
    public void when_all_rolls_have_1_pin_down_score_is_20()
    {
        RollMany(20, 1);
        Assert.AreEqual(20, sut.Score());
    }

    public void RollMany(int rolls, int pinsDown)
    {
        for(int i = 0; i < rolls ; i++)
        {
            sut.Roll(pinsDown);
        }
    }
}