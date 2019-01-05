using System;
using System.Collections.Generic;
using System.Linq;

namespace spliter
{
    public class FindSums
    {
        public static List<(string, string, string)> In(IEnumerable<string> words)
        {
            var result = new List<(string, string, string)>();

            string[] sumCandidates = words.Where(w => w.Length == 6).ToArray();
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
    }
}
