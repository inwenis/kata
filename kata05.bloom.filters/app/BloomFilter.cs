using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace app
{
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

        public string DumpBitMapToBinary()
        {
            var binary = _bitmap
                .Select(b => Convert.ToString(b, 2).PadLeft(8, '0'));
            return string.Join(" ", binary);
        }
    }
}
