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
            if(_rolls[rollIndex] + _rolls[rollIndex+1] == 10)
            {
                score += 10;
                score += _rolls[rollIndex+2];
            }
            else
            {
                score += _rolls[rollIndex];
                score += _rolls[rollIndex+1];
            }
            
            rollIndex += 2;
        }
        return score;
    }
}