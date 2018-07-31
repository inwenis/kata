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
        int rollIndex = 0;
        for(int frame = 0; frame < 10 ; frame++)
        {
            if (IsSpare(_rolls[rollIndex], _rolls[rollIndex+1]))
            {
                score += 10;
                score += _rolls[rollIndex+2];
                rollIndex += 2;
            }
            else if (IsStrike(_rolls[rollIndex])) //strike
            {
                score += 10;
                score += _rolls[rollIndex+1];
                score += _rolls[rollIndex+2];
                rollIndex += 1;
            }
            else
            {
                score += _rolls[rollIndex];
                score += _rolls[rollIndex+1];
                rollIndex += 2;
            }
        }
        return score;
    }

    public bool IsSpare(int roll1, int roll2)
    {
        return roll1 + roll2 == 10;
    }

    public bool IsStrike(int roll)
    {
        return roll == 10;
    }
}