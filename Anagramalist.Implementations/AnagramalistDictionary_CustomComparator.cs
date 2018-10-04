using System.Collections.Generic;
using System.Linq;

namespace anagram_kata2
{
    public class AnagramalistDictionary_CustomComparator : IAnagramalist
    {
        public string[] FindAllAnagrams(string[] words)
        {
            var dic = new Dictionary<char[], string>(new CharArrayComparer());

            foreach (var word in words.Where(x => x.Length > 1))
            {
                var ordered = word.OrderBy(c => c).ToArray();

                if (dic.ContainsKey(ordered))
                {
                    dic[ordered] += " " + word;
                }
                else
                {
                    dic[ordered] = word;
                }
            }

            return dic.Values.Where(x => x.Contains(" ")).ToArray();
        }
    }
}