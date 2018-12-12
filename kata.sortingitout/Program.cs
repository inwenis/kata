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
            rack.Add(20);
            rack.Add(15);
            Console.WriteLine(rack.Balls);
            foreach (var ball in rack.Balls)
            {
                Console.Write(ball + " ");
            }
            Console.WriteLine("[enter] to exit");
            Console.WriteLine(CharacterSorter.Sort("When not studying nuclear physics, Bambi likes to play beach volleyball."));
            Console.WriteLine(CharacterSorter.SortUsingBuildIn("When not studying nuclear physics, Bambi likes to play beach volleyball."));
            Console.ReadLine();
        }
    }
}
