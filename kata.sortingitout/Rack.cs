using System.Collections.Generic;
using System.Linq;

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
            if (_balls.Any() && _balls.First.Value > ball)
            {
                _balls.AddFirst(ball);
            }
            else
            {
                _balls.AddLast(ball);
            }
        }

        public IEnumerable<int> Balls
        {
            get { return _balls; }
        }
    }
}