using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagram_kata2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Anagramalist
    {
        public static string[] FindAllAnagrams(string[] words)
        {
            var anagrams = words
                .GroupBy(word => word.Length)
                .Where(groupedByLength => groupedByLength.Count() > 1)
                .Select(x =>
                {
                    var ordered = new string(x.First().OrderBy(c => c).ToArray());
                    var sameLetters = x.Where(w => new string(w.OrderBy(c => c).ToArray()) == ordered);
                    return string.Join(" ", sameLetters);
                })
                .ToArray();
            return anagrams;
        }
    }
}
