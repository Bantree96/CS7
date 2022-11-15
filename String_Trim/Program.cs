using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Trim
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "[1,0.99],[2,1],";
            str1.TrimEnd(',');
        }
    }
}
