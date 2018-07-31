public class Game
{
    int _score = 0;

    public void Roll(int pinsDown)
    {
        _score += pinsDown;
    }

    public int Score()
    {
        return _score;
    }
}