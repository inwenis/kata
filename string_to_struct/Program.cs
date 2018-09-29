using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_string_vs_struct;

namespace string_to_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("input string, I'll convert it to a struct (q! to exit)");
                var line = Console.ReadLine();
                if (line == "q!")
                {
                    break;
                }
                var @struct = IRepresentOrderdString.FromString(line);
                Console.WriteLine(@struct);
                Console.WriteLine();
            }
        }
    }
}
