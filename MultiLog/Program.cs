using Serilog;
using System.ComponentModel;

namespace MultiLog
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerInit();

            Log.Information($"[System1] : Hello");
            Log.Information($"[System2] : Hello");
        }

        enum Services 
        {
            [Description("System1")]
            System1,
            [Description("System2")]
            System2
        }

        public static void LoggerInit()
        {
            var log = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey(EnumHelper.GetDescription(Services.System1))).WriteTo.File($@"D:\test\System1.log"))
                .WriteTo.Logger(lc => lc.Filter.ByIncludingOnly(evt => evt.Properties.ContainsKey(EnumHelper.GetDescription(Services.System2))).WriteTo.File($@"D:\test\System2.log"))
                .CreateLogger();
        }

    }
}
