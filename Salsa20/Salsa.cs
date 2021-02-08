using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salsa20
{
    public class Salsa
    {
        public List<uint> QuarterRound(List<uint> y)
        {
            List<uint> new_list = new List<uint>();
            uint z1 = y[1] ^ RotateLeft((y[0] + y[3]), 7);
            uint z2 = y[2] ^ RotateLeft((z1 + y[0]), 9);
            uint z3 = y[3] ^ RotateLeft((z2 + z1), 13);
            uint z0 = y[0] ^ RotateLeft((z3 + z2), 18);
            new_list.Add(z0);
            new_list.Add(z1);
            new_list.Add(z2);
            new_list.Add(z3);
            return new_list;
        }
        public List<uint> RowRound(List<uint> y)
        {

            List<uint> new_list = new List<uint>();
            new_list.AddRange(QuarterRound(new List<uint>() { y[0], y[1], y[2], y[3] }));
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[6], y[7], y[4] })[3]);
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[6], y[7], y[4] })[0]);
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[6], y[7], y[4] })[1]);
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[6], y[7], y[4] })[2]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[11], y[8], y[9] })[2]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[11], y[8], y[9] })[3]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[11], y[8], y[9] })[0]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[11], y[8], y[9] })[1]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[12], y[13], y[14] })[1]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[12], y[13], y[14] })[2]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[12], y[13], y[14] })[3]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[12], y[13], y[14] })[0]);
            return new_list;
        }
        public List<uint> ColumnRound(List<uint> y)
        {

            List<uint> new_list = new List<uint>();
            new_list.Add(QuarterRound(new List<uint>() { y[0], y[4], y[8], y[12] })[0]);
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[9], y[13], y[1] })[3]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[14], y[2], y[6] })[2]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[3], y[7], y[11] })[1]);
            new_list.Add(QuarterRound(new List<uint>() { y[0], y[4], y[8], y[12] })[1]);
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[9], y[13], y[1] })[0]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[14], y[2], y[6] })[3]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[3], y[7], y[11] })[2]);
            new_list.Add(QuarterRound(new List<uint>() { y[0], y[4], y[8], y[12] })[2]);
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[9], y[13], y[1] })[1]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[14], y[2], y[6] })[0]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[3], y[7], y[11] })[3]);
            new_list.Add(QuarterRound(new List<uint>() { y[0], y[4], y[8], y[12] })[3]);
            new_list.Add(QuarterRound(new List<uint>() { y[5], y[9], y[13], y[1] })[2]);
            new_list.Add(QuarterRound(new List<uint>() { y[10], y[14], y[2], y[6] })[1]);
            new_list.Add(QuarterRound(new List<uint>() { y[15], y[3], y[7], y[11] })[0]);
            return new_list;
        }
        public List<uint> DoubleRound(List<uint> y)
        {
            return RowRound(ColumnRound(y));
        }

        public uint Littleendian(uint b0, uint b1, uint b2, uint b3)
        {
            return Convert.ToUInt32(b0 + Math.Pow(2, 8) * b1 + Math.Pow(2, 16) * b2 + Math.Pow(2, 24) * b3);
        }
        public List<uint> _Littleendian(uint b)
        {
            List<uint> list = new List<uint>();
            uint b3 = Convert.ToUInt32(b / Math.Pow(2, 24));
            b -= Convert.ToUInt32(Math.Pow(2, 24) * b3);
            uint b2 = Convert.ToUInt32(b / Math.Pow(2, 16));
            b -= Convert.ToUInt32(Math.Pow(2, 16) * b2);
            uint b1 = Convert.ToUInt32(b / Math.Pow(2, 8));
            b -= Convert.ToUInt32(Math.Pow(2, 8) * b1);
            list.Add(b);
            list.Add(b1);
            list.Add(b2);
            list.Add(b3);
            return list;
        }
        public List<uint> Salsa20(List<uint> y)
        {
            List<uint> list = new List<uint>();
            List<uint> listX = new List<uint>();
            for (int i = 0; i < 64; i += 4)
            {
                listX.Add(Littleendian(y[i], y[i + 1], y[i + 2], y[i + 3]));
            }
            List<uint> listZ = DoubleRound(listX);
            for (int k = 0; k < 9; k++)
            {
                listZ = DoubleRound(listZ);
            }
            for (int p = 0; p<16; p++)
            {
                list.AddRange(_Littleendian(listZ[p] + listX[p]));
            }
            return list;
        }
        private uint RotateLeft(uint value, int offset)
        {
            return (value << offset) | (value >> (32 - offset));
        }
    }
}
