using System.Collections.Generic;
using Newtonsoft.Json;

namespace Json_Use.Models.DFS
{
    public class DFS_Status
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int status { get; set; }
        public IN_DATA_Class refDS { get; set; }

        public DFS_Status()
        {
            // DFS_Status Property 생성된 다음 IN_DATA1이 생성
            IN_DATA_Class in_data = new IN_DATA_Class();
            refDS = in_data;
        }

    }


}
