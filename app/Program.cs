using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            BloomFilter bm = new BloomFilter(64 * 1024, 5);
            var words = File.ReadAllLines("wordlist.txt");
            System.Console.WriteLine("Adding word to bloom filter...");
            foreach(var word in words)
            {
                bm.Add(word);
            }
            System.Console.WriteLine("Done adding word to bloom filter");

            System.Console.WriteLine("Checking if all words belong to dictionary...");
            foreach(var word in words)
            {
                var check = bm.Check(word);
                if(!check)
                {
                    System.Console.WriteLine("we have a problem!");
                    System.Console.WriteLine(word);
                }
            }
            System.Console.WriteLine("Done checking if all words belong to dictionary");

            System.Console.WriteLine("Gimmie a word and I'll check if it is in the dictionary");
            System.Console.WriteLine("type `q` (without the backticks) to exit");
            string input;
            do
            {
                input = System.Console.ReadLine();
                System.Console.WriteLine($"Checking if {input} belongs to dictionary");
                var check = bm.Check(input);
                System.Console.WriteLine(check);
            }while(input != "q");
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
        private MD5 _md5Hash;
        private byte[] _randoms;
        public BloomFilter(int len, int hashCount)
        {
            _bitmap = new byte[len];
            _md5Hash = MD5.Create();
            _randoms = new byte[hashCount];
            Random random = new Random();
            random.NextBytes(_randoms);
        }

        public void Add(string word)
        {
            var addresses = GetAddress(word);
            foreach((int, byte) address in addresses)
            {
                int byteAddress = address.Item1;
                int bitInByte = address.Item2;
                _bitmap[byteAddress] = (byte) (_bitmap[byteAddress] | bitInByte);
            }
        }

        public bool Check(string word)
        {
            var adresses = GetAddress(word);
            bool wordInDictionary = adresses.All(address => {
                int byteAddress = address.Item1;
                int bitInByte = address.Item2;
                return (_bitmap[byteAddress] & bitInByte) != 0;
            });
            return wordInDictionary;
        }

        private (int, byte)[] GetAddress(string word)
        {
            (int, byte)[] addresses = new (int, byte)[_randoms.Length];
            byte[] wordBytes = Encoding.UTF8.GetBytes(word);
            for (int i = 0; i < _randoms.Length; i++)
            {
                byte random = _randoms[i];
                byte[] xoredBytes = wordBytes.Select(b => (byte)(b ^ random)).ToArray();
                byte[] hash = _md5Hash.ComputeHash(wordBytes);
                int address = Math.Abs(BitConverter.ToInt32(hash));
                int bitAddress = address % (_bitmap.Length * 8);
                int byteAddress = bitAddress/8;
                byte bitInByte = (byte)(1 << (bitAddress - byteAddress * 8));
                addresses[i] = (byteAddress, bitInByte);
            }
            
            return addresses;
        }
    }
}
