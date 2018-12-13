using System;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using kata.sortingitout;

namespace MyBenchmarks
{
    public class MyBench
    {
        private const int N = 10000;
        private readonly byte[] data;
        protected internal string _text;

        public MyBench()
        {
            data = new byte[N];
            var random = new Random(DateTimeOffset.UtcNow.Millisecond);
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte) random.Next('A', 'z');
            }

            _text = Encoding.UTF8.GetString(data);
        }

        [Benchmark]
        public string Custom() => CharacterSorter.Sort(_text);

        [Benchmark]
        public string BuildIn() => CharacterSorter.SortUsingBuildIn(_text);
    }
}