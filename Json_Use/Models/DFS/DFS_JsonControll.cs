// Json을 사용하기위한 라이브러리 using
using Json_Use.Models.DFS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Timers;

namespace Json_Use.Models
{
    public class DFS_JsonControll
    {
        #region Field
        DFS_Status status_data = new DFS_Status();
        private Timer statusTimer;

        #endregion
        public DFS_JsonControll()
        {
            // TODO : 1. 10초마다 Status JSON 생성 후 저장
            SetTimer();
        }
        /*
        private void CreateStateJson()
        {
            JObject status = new JObject(
                new JProperty("TXN_ID", status_data.Id),
                new JProperty("TXN_Name", status_data.Name),
                new JProperty("TXN_State", status_data.status),
                new JProperty("refDS",
                    new JArray("IN_DATA", new JObject(
                            new JProperty("CATEGORY", "123"),
                            new JProperty("TRANSFER_TIME", "123")
                        )
                    )));

            // TODO : 2. 저장 기능 필요
            File.WriteAllText(@"D:\test.json", status.ToString());
        }*/
        #region Method
        public void CreateJsonFile()
        {
               
        }

        public void SetTimer()
        {
            statusTimer = new System.Timers.Timer(10000);
            statusTimer.Elapsed += OnTimedEvent;
            statusTimer.AutoReset = true;
            statusTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            CreateStateJson();
        }

        
        
        // Json Serialize, Deserialize 방식
        public void CreateStateJson()
        {
            // Json string 만들기
            //var p = new State_Json { Id = 1, Name = "Alex" };
            object p = new DFS_Status();
            string jsonString = JsonConvert.SerializeObject(p);
            //Console.WriteLine(jsonString);

            File.WriteAllText(@"D:\test.json", jsonString);

            // Json string으로부터 Object 가져오기
            p = JsonConvert.DeserializeObject<object>(File.ReadAllText(@"D:\test.json"));
            Console.WriteLine(p);
        }
        
        public void CreateDataJson()
        {

        }
        #endregion

    }
}
