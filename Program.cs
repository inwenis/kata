using System;

namespace kata02.karate.chop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Chop(5, new []{1,3,5});
            Chop(3, new int []{});
            Chop(3, new int []{1});
            Chop(1, new int []{1});
            //
            Chop(1, new int []{1, 3, 5});
            Chop(3, new int []{1, 3, 5});
            Chop(5, new int []{1, 3, 5});
            Chop(0, new int []{1, 3, 5});
            Chop(2, new int []{1, 3, 5});
            Chop(4, new int []{1, 3, 5});
            Chop(6, new int []{1, 3, 5});
            //
            Chop(1, new int []{1, 3, 5, 7});
            Chop(3, new int []{1, 3, 5, 7});
            Chop(5, new int []{1, 3, 5, 7});
            Chop(7, new int []{1, 3, 5, 7});
            Chop(0, new int []{1, 3, 5, 7});
            Chop(2, new int []{1, 3, 5, 7});
            Chop(4, new int []{1, 3, 5, 7});
            Chop(6, new int []{1, 3, 5, 7});
            Chop(8, new int []{1, 3, 5, 7});
        }

        public static int Chop(int searchFor, int[] array)
        {
            if(array.Length >= 1)
            {
                int @from = 0;
                int to = array.Length;

                while (to - @from > 0)
                {
                    int check = @from + (to - @from)/2;
                    System.Console.WriteLine($"{@from} {to} {check}");
                    if (array[check] == searchFor)
                    {
                        return check;
                    }
                    else if (array[check] > searchFor)
                    {
                        @from = @from;
                        to = check - 1;
                    }
                    else
                    {
                        @from = check + 1;
                        to = to;
                    }
                }

                return -1;
            }
            else
            {
                return -1;
            }
        }
    }
}
