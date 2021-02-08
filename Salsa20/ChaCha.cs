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
        
        private uint RotateLeft(uint value, int offset)
        {
            return (value << offset) | (value >> (32 - offset));
        }

    }
}
