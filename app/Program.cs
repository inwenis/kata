using System;
using System.Text;
using System.Security.Cryptography;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            BloomFilter bm = new BloomFilter(1024);
            bm.Add("word");
            bm.Add("test");
            bm.Add("aaa");
            bm.Add("bbb");

            System.Console.WriteLine($"word: {bm.Check("word")}");
            System.Console.WriteLine($"test: {bm.Check("test")}");
            System.Console.WriteLine($"aaa:  {bm.Check("aaa")}");
            System.Console.WriteLine($"bbb:  {bm.Check("bbb")}");
            System.Console.WriteLine($"ccc:  {bm.Check("ccc")}");
            System.Console.WriteLine($"this: {bm.Check("this")}");
        }

        public static decimal ByteArrayToDecimal(byte[] src, int offset)
        {
            var i1 = BitConverter.ToInt32(src, offset);
            var i2 = BitConverter.ToInt32(src, offset + 4);
            var i3 = BitConverter.ToInt32(src, offset + 8);
            var i4 = BitConverter.ToInt32(src, offset + 12);

            return new decimal(new int[] { i1, i2, i3, i4 });
        }
    }

    class BloomFilter
    {
        private byte[] _bitmap;
        public BloomFilter(int len)
        {
            _bitmap = new byte[len];
        }

        public void Add(string word)
        {
            MD5 md5Hash = MD5.Create();
            byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(word));
            int address = Math.Abs(BitConverter.ToInt32(hash));
            int bitAddress = address % (_bitmap.Length * 8);
            int byteAddress = bitAddress/8;
            byte x = (byte)(1 << (bitAddress - byteAddress * 8));
            _bitmap[byteAddress] = (byte) (_bitmap[byteAddress] | x);
        }

        public bool Check(string word)
        {
            MD5 md5Hash = MD5.Create();
            byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(word));
            int address = Math.Abs(BitConverter.ToInt32(hash));
            int bitAddress = address % (_bitmap.Length * 8);
            int byteAddress = bitAddress/8;
            byte x = (byte)(1 << (bitAddress - byteAddress * 8));
            return (_bitmap[byteAddress] & x) != 0;
        }
    }
}
