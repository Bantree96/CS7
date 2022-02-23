using System;

namespace Reflection_Plugin_Create2
{
    [PluginAttribute]
    public class SystemInfo
    {
        bool _is64Bit;

        public SystemInfo()
        {
            _is64Bit = Environment.Is64BitOperatingSystem;
            Console.WriteLine("SystemInfo Created");
        }

        // 특성 적용
        [StartupAttribute]
        public void WriteInfo()
        {
            Console.WriteLine("OS = {0}bits", (_is64Bit == true) ? "64" : "32");
        }
    }


    // 특성 생성
    public class PluginAttribute : Attribute { }
    public class StartupAttribute : Attribute { }
}
