using System;
using System.Collections.Generic;
using System.Linq;

namespace spliter
{
    public class FindSums
    {
        public static IEnumerable<(string, string, string)> In(IEnumerable<string> words)
        {
            var result = new List<(string, string, string)>();

            string[] sumCandidates = words.Where(w => w.Length == 6).ToArray();
            HashSet<string> summands = new HashSet<string>(words.Where(w => w.Length < 6));

            foreach (string sumCandidate in sumCandidates)
            {
                var augends = summands.Where(s => sumCandidate.StartsWith(s));

                foreach(string augend in augends)
                {
                    string addend = sumCandidate.Substring(augend.Length);
                    if(summands.Contains(addend))
                    {
                        yield return (augend, addend, sumCandidate);
                    }
                }
            }
        }
    }
}
