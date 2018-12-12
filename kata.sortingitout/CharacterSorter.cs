using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kata.sortingitout
{
    public class CharacterSorter
    {
        public static string Sort(string input)
        {
            var characterCount = new Dictionary<char, int>();
            for (char i = 'a'; i < 'z'; i++)
            {
                characterCount.Add(i, 0);
            }

            for (int i = 0; i < input.Length; i++)
            {
                var character = input[i];
                characterCount[character]++;
            }

            var builder = new StringBuilder(input.Length);
            foreach (var keyValuePair in characterCount.OrderBy(x => x.Key))
            {
                var character = keyValuePair.Key;
                var count = keyValuePair.Value;
                builder.Append(character, count);
            }
            return builder.ToString();
        }
    }
}
