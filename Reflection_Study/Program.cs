using System;
using System.Reflection;
using PropertyChanged;

namespace Reflection_Study
{
    // [AddINotifyPropertyChangedInterface]
    class Program
    {
        // AppDomain은 콘솔프로그램에서만 나온다.
        static AppDomain currentDomain = AppDomain.CurrentDomain;

        static void Main(string[] args)
        {
            // Module_Type();
            Assembly_Type(currentDomain);
        }

        /// <summary>
        /// 모듈의 타입을 출력한다.
        /// </summary>
        static void Module_Type(AppDomain currentDomain)
        {
            
            Console.WriteLine("Current Domain Name: " + currentDomain.FriendlyName);
            foreach (Assembly asm in currentDomain.GetAssemblies())
            {
                // 파일 이름과 버전 등이 나옴
                Console.WriteLine("  " + asm.FullName);

                foreach (Module module in asm.GetModules())
                {
                    // DLL, EXE 경로가 나옴
                    Console.WriteLine("  " + module.FullyQualifiedName);

                    foreach (Type type in module.GetTypes())
                    {
                        // 그 DLL or EXE에서 사용할수있는 타입 -> using으로 사용중인 모든것
                        Console.WriteLine("  " + type.FullName);
                    }
                }
            }
        }

        /// <summary>
        /// 어셈블리의 타입을 출력한다.
        /// </summary>
        static void Assembly_Type(AppDomain currentDomain)
        {
            foreach (Assembly asm in currentDomain.GetAssemblies())
            {
                Console.WriteLine("  " + asm.FullName);

                foreach (Type type in asm.GetTypes())
                {
                    Console.WriteLine("  " + type.FullName);

                }
            }
        }
    }
}
