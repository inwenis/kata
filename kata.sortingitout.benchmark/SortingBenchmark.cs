using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using kata.sortingitout;

namespace MyBenchmarks
{
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvMeasurementsExporter, RPlotExporter]
    public class SortingBenchmark
    {
        protected internal string _text100;
        protected internal string _text200;
        protected internal string _text1000;

        public SortingBenchmark()
        {
            _text100 = RandomString(1000);
            _text200 = RandomString(2000);
            _text1000 = RandomString(3000);
        }

        private static string RandomString(int length)
        {
            var random = new Random(DateTimeOffset.UtcNow.Millisecond);
            byte[] data = new byte[length];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte) random.Next('A', 'z');
            }

            var text = Encoding.UTF8.GetString(data);
            return text;
        }

//        [Benchmark]
//        public string Custom() => CharacterSorter.Sort(_text);

        [Benchmark]
        public string Test1000() => CharacterSorter.Sort(_text1000);
    }
}