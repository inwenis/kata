using NUnit.Framework;

[TestFixture]
public class GameTests
{
    [Test]
    public void when_all_rolls_have_0_pins_down_score_is_0()
    {
        Game sut = new Game();
        for(int i = 0; i < 20 ; i++) {
            sut.Roll(0);
        }
        Assert.AreEqual(0, sut.Score());
    }

    [Test]
    public void when_all_rolls_have_1_pin_down_score_is_20()
    {
        Game sut = new Game();
        for(int i = 0; i < 20 ; i++) {
            sut.Roll(1);
        }
        Assert.AreEqual(20, sut.Score());
    }
}