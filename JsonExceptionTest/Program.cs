using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExceptionTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = $@"C:\Users\TS_jiwon\Desktop\Error.json";
			try
			{
				// Json을 읽어오는 기능
				string str_Json = File.ReadAllText(text);
				JObject jObj = JObject.Parse(str_Json);
			}
			catch (JsonException ex)
			{
				File.Delete(text);
			}
			catch (Exception)
			{
				// Json 예외 발생시 해당 파일 삭제 기능
				throw;
			}
		}
	}
}
