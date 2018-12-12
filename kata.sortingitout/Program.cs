using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata.sortingitout
{
    class Program
    {
        static void Main(string[] args)
        {
            var rack = new Rack();
            rack.Add(12);
            Console.WriteLine(rack.Balls);
            foreach (var ball in rack.Balls)
            {
                Console.Write(ball + " ");
            }
        }
    }
}
