using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salsa20
{
    public class ChaCha
    {
        public List<uint> QuarterRound(List<uint> list)
        {
            List<uint> res = new List<uint>();
            uint a = list[0];
            uint b = list[1];
            uint c = list[2];
            uint d = list[3];

            //a += b; d ^= a; d = RotateLeft(d, 16);
            //c += d; b ^= c; b = RotateLeft(b, 12);
            //a += b; d ^= a; d = RotateLeft(d, 8);
            //c += d; b ^= c; b = RotateLeft(b, 7);
            a += b; d = RotateLeft(d ^ a, 16);
            c += d; b = RotateLeft(b ^ c, 12);
            a += b; d = RotateLeft(d ^ a, 8);
            c += d; b = RotateLeft(b ^ c, 7);
            res.Add(a);
            res.Add(b);
            res.Add(c);
            res.Add(d);
            return res;

        }
        public List<string> UintToStr(List<uint> list)
        {
            string str;
            List<string> list_str = new List<string>();
            foreach (uint i in list)
            {
                str = i.ToString("X");
                if (str.Length < 8)
                {
                    int count = 8 - str.Length;
                    for (int p = 0; p < count; p++)
                    {
                        str = "0" + str;
                    }
                }
                str = "0x" + str;
                list_str.Add(str);
            }
            return list_str;
        }
        public string UintToStr(uint str)
        {
            string res = str.ToString("X");
            if (res.Length < 8)
            {
                int count = 8 - res.Length;
                for (int p = 0; p < count; p++)
                {
                    res = "0" + res;
                }
            }
            res = "0x" + res;

            return res;
        }
        private uint RotateLeft(uint value, int offset)
        {
            return (value << offset) | (value >> (32 - offset));
        }

    }
}
