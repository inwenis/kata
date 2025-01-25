using System.Collections.Generic;

namespace kata.sortingitout
{
    public class Rack
    {
        private LinkedList<int> _balls;

        public Rack()
        {
            _balls = new LinkedList<int>();
        }

        public void Add(int ball)
        {
            if (_balls.First == null)
            {
                _balls.AddFirst(ball);
            }
            else
            {
                var traveler = _balls.First;
                while (true)
                {
                    if (traveler.Value > ball)
                    {
                        _balls.AddBefore(traveler, ball);
                        break;
                    }
                    else if (traveler.Next == null)
                    {
                        _balls.AddAfter(traveler, ball);
                        break;
                    }
                    else
                    {
                        traveler = traveler.Next;
                    }
                }
            }
        }

        public IEnumerable<int> Balls
        {
            get { return _balls; }
        }
    }
}