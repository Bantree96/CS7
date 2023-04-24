using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 *  2023.04.24 남지원 
 *  Directory.Exists와 DirectoryInfo.Exists의 속도 비교 테스트
 * 
 *  1. 처음 디스크에 접근할 때는 속도가 느리다.
 *  2. 아예 없는 경로에 접근할 때는 가끔 속도가 튄다. 

 *  23.04.24 : 최대 26초까지 튀는거 확인
 */
namespace DirectoryExists
{
    class Program
    {
        static Stopwatch _sw = new Stopwatch();

        static void Main(string[] args)
        {
            // 처음 접근할 때 느림

            // SSD
            DirectoryExists($@"C:\test", true);
            DirectoryExists($@"C:\asd", false);
            DirectoryExists($@"C:\test", true);

            DirecotryInfoExists($@"C:\test", true);
            DirecotryInfoExists($@"C:\asd", false);
            DirecotryInfoExists($@"C:\test", true);

            // HDD
            DirectoryExists($@"D:\test", true);
            DirectoryExists($@"D:\asd", false);
            DirectoryExists($@"D:\test", true);

            // 완전 없는 경로
            DirecotryInfoExists($@"\\213.214.215.123\test", false);
            DirectoryExists($@"\\213.214.215.123\test", false);

        }

        static void DirectoryExists(string path, bool Exists)
        {
            _sw.Restart();

            var a = Directory.Exists(path);

            _sw.Stop();

            if (Exists)
            {
                Console.WriteLine($"{path} : {_sw.Elapsed}");
            }
            else
            {
                Console.WriteLine($"{path}  : {_sw.Elapsed}");
            }
        }

        static void DirecotryInfoExists(string path, bool Exists)
        {
            _sw.Restart();

            DirectoryInfo di = new DirectoryInfo(path);
            _ = di.Exists;

            _sw.Stop();

            if (Exists)
            {
                Console.WriteLine($"{path}  : {_sw.Elapsed}");
            }
            else
            {
                Console.WriteLine($"{path}  : {_sw.Elapsed}");
            }
        }
    }
}
