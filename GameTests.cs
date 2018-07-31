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

    public void RollMany(int rolls, int pinsDown)
    {
        for(int i = 0; i < rolls ; i++)
        {
            sut.Roll(pinsDown);
        }
    }

    public void RollSpare()
    {
        sut.Roll(5);
        sut.Roll(5);
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

    [Test]
    public void when_2_rolls_in_a_frame_knock_down_all_pins_bonus_for_spare_doubles_pins_from_next_roll()
    {
        RollSpare();
        RollMany(1, 2);
        RollMany(17, 0);
        Assert.AreEqual(14, sut.Score());
    }
}
