using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;

namespace Serliog_Test
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error;

            Log.Logger = new LoggerConfiguration()
               // 로그 남기는 기준 Verbose
               .MinimumLevel.ControlledBy(levelSwitch)

               // Thread Id 가져오기
               //.Enrich.WithThreadName()

               // 파일에 로그 출력
               .WriteTo.File(@"logs\{Date:YYYY}_{Date:MM}_{Date:DD}_SystemLog.txt",
                    // [시간][레벨][쓰레드명][메세지][\n][예외]
                    outputTemplate: "[{Timestamp:yyyy-MM-dd_HH:mm:ss:fff}] [{Level:u3}] <{ThreadName}> {Message:l}{NewLine} {Exception}",
                    rollingInterval: RollingInterval.Minute,
                    rollOnFileSizeLimit: false,  // 로그 파일 최대 사이즈 1GB
                    retainedFileCountLimit: 31  // 로그 파일 갯수 기본 31개
               ).CreateLogger();

            // Logger 자체의 문제를 콘솔로그로 남겨줌
            //Serilog.Debugging.SelfLog.Enable(Console.Error);

            Exception ex = new Exception("임시로만든 예외");

            while (true)
			{

                Log.Information("============= XML 불러오기 Start =================");
                Log.Fatal(ex, "카메라가 없습니다.");
                Log.Error(ex, "에러 없습니다.");
                Log.Warning(ex, "경고 없습니다.");
                Log.Verbose(ex, "내용 없습니다.");

                Thread.Sleep(1000);
            }
          

        }


    }

    class Logger
    {
        
    }
}
