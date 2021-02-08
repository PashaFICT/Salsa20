using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salsa20
{
    class Conversion
    {
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
    }
}
