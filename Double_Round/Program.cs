using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_Round
{
    class Program
    {
        static void Main(string[] args)
        {
            double numA = 123.456789;
            double numB = Math.Truncate(numA * 100) / 100;
            Console.WriteLine(numB);
        }
    }
}
