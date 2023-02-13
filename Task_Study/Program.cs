using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Study
{
    class Program
    {
        // Task는 두가지 버전의 형식이 있다.
        // Action을 사용하는 return 없는 버전
        // Func<T>를 사용하는 return 있는 버전
        
        /// <summary>
        /// 인자가 없는 함수
        /// </summary>
        static void Foo1() { Console.WriteLine("Foo1"); }

        /// <summary>
        /// 인자가 있는 함수
        /// </summary>
        /// <param name="obj"></param>d
        static void Foo2(object obj) { Console.WriteLine($"Foo2 : {obj}"); }

        static int Foo3() { Console.WriteLine("Foo3"); return 100; }

        static int Foo4(object obj) { Console.WriteLine($"Foo4 : {obj}"); return 100; }
        static void Foo5() { Console.WriteLine($"Foo5"); }
        
        static int Foo6()
        {
            Console.WriteLine("Foo6");
            Thread.Sleep(1000);
            return 200;
        }

        static void Foo7()
        {
            Console.WriteLine($"{Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"{Thread.CurrentThread.IsBackground}");
        }

        /// <summary>
        /// ThreadPool을 사용하지 않는 Task 만들기
        /// </summary>
        static void Foo8()
        {
            Thread.Sleep(2000);
        }

        static void Main(string[] args)
        {
            Task t1 = new Task(Foo1);
            t1.Start();

            Task t2 = new Task(Foo2, "Hello World");
            t2.Start();

            Task<int> t3 = new Task<int>(Foo3);
            t3.Start();

            Task<int> t4 = new Task<int>(Foo4, "Hello World");
            t4.Start();

            // 객체를 만들지 않고 정적 메소드 사용가능
            // 단 인자가 없는 메소드만 사용가능. 인자를 사용하려면 람다식을 써야함
            Task.Run(Foo5);

            Task t5 = Task.Run(Foo5);
            t5.Wait(); // Run 스태틱 메소드로 바로 실행하더라도 return 되는 Task객체를 이용해 wait가능

            var t6 = new Task<int>(Foo6);
            t6.Start();

            // Thread가 종료 될 때까지 대기
            t6.Wait();

            int result = t6.Result; // 만일 wait를 안한 경우, Thread가 종료 될 때까지 대기한다.
            Console.WriteLine($"{result}");
            
            // Wait가 없다면 끝날 때 까지 기다리지않고 그냥 끝내버림
            Task.Run(Foo7).Wait();


            var t8 = new Task(Foo8, TaskCreationOptions.LongRunning); // 블록킹 작업 등 시간이 오래걸리는 Thread를 Pool에 만들지 않기 위해 주는 옵션
            t8.Start();
            t8.Wait();
        }
    }
}
