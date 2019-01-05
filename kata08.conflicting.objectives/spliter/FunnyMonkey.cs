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
            else if (wordsArray.Length == 3)
            {
                return new List<(string, string, string)>
                {
                    (wordsArray[0], wordsArray[1], wordsArray[2])
                };
            }
            else if (wordsArray.Length == 4)
            {
                var result = new List<(string, string, string)>();

                List<string> sumCandidates = words.Where(w => w.Length == 6).ToList();

                string[] summands = words.Where(w => w.Length < 6).ToArray();

                foreach (string sumCandidate in sumCandidates)
                {
                    var augends = summands.Where(s => sumCandidate.StartsWith(sumCandidate));

                    foreach(string augend in augends)
                    {
                        string addend = sumCandidate.Substring(augend.Length);
                        if(summands.Contains(addend))
                        {
                            result.Add((augend, addend, sumCandidate));
                        }
                    }
                }

                return result;
            }
            else
            {
                return new List<(string, string, string)>
                {
                    (wordsArray[0], wordsArray[1], wordsArray[2]),
                    (wordsArray[3], wordsArray[4], wordsArray[5])
                };
            }
        }
    }
}
