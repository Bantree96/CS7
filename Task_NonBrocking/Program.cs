using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_NonBrocking
{
    class Program
    {
        public static int Foo(object obj)
        {
            int count = (int)obj;
            int result = 0;
            Console.WriteLine("Start Task Foo");
            for(int i=0; i<=count; i++)
            {
                Thread.Sleep(100);
                result += i;
            }
            Console.WriteLine("Finish Task Foo");
            return result;
        }

        public static void Bar(int input)
        {
            Console.WriteLine($"Print result in Bar : {input}");
        }

        public static void Bar(Task<int> t)
        {
            Console.WriteLine($"Print result in Bar : {t.Result}");
        }

        static void Main(string[] args)
        {
            var t = Task.Run(() => Foo(10));

            // int result = t.Result;
            // Bar(result);

            t.ContinueWith(Bar); // Bar Method를 연속작업에 등록한다.

            Console.WriteLine("Main Thread");
            Console.ReadLine();
        }
    }
}
