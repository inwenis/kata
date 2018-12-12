using System.Collections.Generic;
using System.Linq;

namespace kata.sortingitout
{
    public class Rack
    {
        private List<int> _balls;

        public Rack()
        {
            _balls = new List<int>();
        }

        public void Add(int ball)
        {
            if (_balls.Any() && _balls[0] > ball)
            {
                _balls.Insert(0, ball);
            }
            else
            {
                _balls.Add(ball);
            }
        }

        public IEnumerable<int> Balls
        {
            get { return _balls; }
        }
    }
}