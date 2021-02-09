using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salsa20
{
    class Program
    {
        static void Main(string[] args)
        {
            Salsa salsa = new Salsa();
            ChaCha chacha = new ChaCha();
            Conversion conversion = new Conversion();
            List<uint> list0 = new List<uint> { 0x11111111, 0x01020304, 0x9b8d6f43, 0x01234567 };
            List<uint> list1 = new List<uint> { 0x00000000, 0x00000000, 0x00000000, 0x00000000 };
            List<uint> list2 = new List<uint> { 0x00000001, 0x00000000, 0x00000000, 0x00000000 };
            List<uint> list3 = new List<uint> { 0x00000000, 0x00000001, 0x00000000, 0x00000000 };
            List<uint> list4 = new List<uint> { 0x00000000, 0x00000000, 0x00000001, 0x00000000 };
            List<uint> list5 = new List<uint> { 0x00000000, 0x00000000, 0x00000000, 0x00000001 };
            List<uint> list6 = new List<uint> { 0xe7e8c006, 0xc4f9417d, 0x6479b4b2, 0x68c67137};
            List<uint> list7 = new List<uint> { 0xd3917c5b, 0x55f1c407, 0x52a58a7a, 0x8f887a3b };
            List<uint> list8 = new List<uint> { 0x00000001, 0x00000000, 0x00000000, 0x00000000, 0x00000001, 0x00000000, 0x00000000, 0x00000000, 0x00000001, 0x00000000, 0x00000000, 0x00000000, 0x00000001, 0x00000000, 0x00000000, 0x00000000 };
            List<uint> list9 = new List<uint> { 0x00000001, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000, 0x00000000 };
            List<uint> list10 = new List<uint> { 211, 159, 13, 115, 76, 55, 82, 183, 3, 117, 222, 37, 191, 187, 234, 136, 49, 237, 179, 48, 1, 106, 178, 219, 175, 199, 166, 48, 86, 16, 179, 207, 31, 240, 32, 63, 15, 83, 93, 161, 116, 147, 48, 113, 238, 55, 204, 36, 79, 201, 235, 79, 3, 81, 156, 47, 203, 26, 244, 243, 88, 118, 104, 54 };

             Console.WriteLine("QuoterRound");
             foreach (string str in conversion.UintToStr(salsa.QuarterRound(list5)))
             {
                 Console.Write(str + " ");
             }
             Console.WriteLine();
             Console.WriteLine("RowRound");
             for (int i = 0; i< conversion.UintToStr(salsa.RowRound(list8)).Count;i++)
             {
                 if (i % 4 == 0 && i != 0) Console.WriteLine();
                 Console.Write(conversion.UintToStr(salsa.RowRound(list8))[i] + " ");
             }
             Console.WriteLine();
             Console.WriteLine("ColumnRound");
             for (int i = 0; i < conversion.UintToStr(salsa.ColumnRound(list8)).Count; i++)
             {
                 if (i % 4 == 0 && i != 0) Console.WriteLine();
                 Console.Write(conversion.UintToStr(salsa.ColumnRound(list8))[i] + " ");
             }
             Console.WriteLine();
             Console.WriteLine("DoubleRound");
             for (int i = 0; i < conversion.UintToStr(salsa.DoubleRound(list8)).Count; i++)
             {
                 if (i % 4 == 0 && i != 0) Console.WriteLine();
                 Console.Write(conversion.UintToStr(salsa.DoubleRound(list8))[i] + " ");
             }
             Console.WriteLine();
             Console.WriteLine("Littleendian for 86, 75, 30, 9");
             Console.WriteLine(conversion.UintToStr(salsa.Littleendian(86, 75, 30, 9)));
             Console.WriteLine("_Littleendian for 0x091e4b56");
             foreach (uint str in salsa.Backwards_Littleendian(0x091e4b56))
             {
                 Console.Write(str.ToString() + " ");
             }
             Console.WriteLine();
             Console.WriteLine("QuoterRound");
             foreach (string str in conversion.UintToStr(chacha.QuarterRound(list0)))
             {
                 Console.Write(str + " ");
             }
             Console.WriteLine();
            //Console.WriteLine(chacha.RotateLeft(0x59876543, 5).ToString("X"));
            Console.Read();
        }
    }
}
