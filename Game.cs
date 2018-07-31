public class Game
{
    int[] _rolls = new int[21];
    int _currentRollIndex = 0;

    public void Roll(int pinsDown)
    {
        _rolls[_currentRollIndex++] = pinsDown;
    }

    public int Score()
    {
        int score = 0;
        foreach(var roll in _rolls)
        {
            score += roll;
        }
        return score;
    }
}