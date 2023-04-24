using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryEnum_Study
{
    class Program
    {
        static string _path = $@"D:\Test\";
        static void Main(string[] args)
        {
            // 디렉토리 정보가 담김
            DirectoryInfo di = new DirectoryInfo(_path);
            di.EnumerateFiles("*.bmp", SearchOption.TopDirectoryOnly).FirstOrDefault();
        }
    }
}
