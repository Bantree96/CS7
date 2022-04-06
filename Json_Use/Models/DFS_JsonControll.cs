// Json을 사용하기위한 라이브러리 using
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Json_Use.Models
{
    public class DFS_JsonControll
    {
        #region Field
        Status_Json status_data = new Status_Json();

        #endregion
        public DFS_JsonControll()
        {
            Timer timer = new Timer(CreateStateJson, null, 0, 10000);

            // TODO : 1. 10초마다 Status JSON 생성 후 저장
            // 10초니까 타이머로 처리하면 될듯
        }

        private void CreateStateJson(object state)
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
        }
        #region Method
        public void CreateJsonFile()
        {
               
        }

        /*
        
        // 일반 Json 방식
        public void CreateStateJson()
        {
            // Json string 만들기
            var p = new State_Json { Id = 1, Name = "Alex" };
            string jsonString = JsonConvert.SerializeObject(p);
            Console.WriteLine(jsonString);

            // Json string으로부터 Object 가져오기
            State_Json pObj = JsonConvert.DeserializeObject<State_Json>(jsonString);
            Console.WriteLine(pObj.Name);
        }
        */
        public void CreateDataJson()
        {

        }
        #endregion
    }

    public class Status_Json
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Alex";
        public int status { get; set; } = 1;
        public List<string> refDS { get; set; }
    }

    public class Data_Json
    {

    }
}
