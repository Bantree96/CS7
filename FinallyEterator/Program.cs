using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyEterator
{
    class Program
    {
        static IEnumerable<string> Iterator()
        {
            try
            {
                Console.WriteLine("Before first yield");
                yield return "first";
                Console.WriteLine("Between yield");
                yield return "Second";
                Console.WriteLine("After second yield");
            }
            finally
            {
                Console.WriteLine("In Finally Block");
            }
        }
        static void Main(string[] args)
        {
            foreach(string value in Iterator())
            {
                Console.WriteLine($"Received value : {value}");
            }
        }
    }
}
