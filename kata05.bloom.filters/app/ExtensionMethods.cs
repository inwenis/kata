using System;
using System.Linq;

namespace app
{
    public static class ExtensionMethods
    {
        public static string NextLowerCaseWord(this Random @this, int length)
        {
            char[] chars = Enumerable
                    .Range(1, length)
                    .Select(x => (char) @this.Next('a', 'z'))
                    .ToArray();
            return new string(chars);
        }
    }
}
