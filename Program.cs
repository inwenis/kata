using System;

namespace kata02.karate.chop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int Chop(int searchFor, int[] array)
        {
            if(array.Length >= 1)
            {
                return array[0] == searchFor ? 0 : -1;
            }
            else
            {
                return -1;
            }
        }
    }
}
