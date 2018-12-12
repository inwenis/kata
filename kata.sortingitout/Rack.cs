using System.Collections.Generic;

namespace kata.sortingitout
{
    public class Rack
    {
        private List<int> _balls;

        public Rack()
        {
            _balls = new List<int>();
        }

        public void Add(int index)
        {
            _balls.Add(index);
        }

        public IEnumerable<int> Balls
        {
            get { return _balls; }
        }
    }
}