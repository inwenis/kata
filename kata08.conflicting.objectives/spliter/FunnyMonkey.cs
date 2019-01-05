using System;
using System.Collections.Generic;
using System.Linq;

namespace spliter
{
    public class FunnyMonkey
    {
        public static List<(string, string, string)> EatBanana(IEnumerable<string> words)
        {
            string[] wordsArray = words.ToArray();
            if(wordsArray.Length == 0)
            {
                return new List<(string, string, string)>();
            }
            else
            {
                return new List<(string, string, string)>
                {
                    (wordsArray[0], wordsArray[1], wordsArray[2])
                };
            }
        }
    }
}
