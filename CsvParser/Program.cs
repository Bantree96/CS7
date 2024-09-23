using CsvParser.Datas;
using CsvParser.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser
{
	class Program
	{
		public static List<Student> Students = new List<Student>();
		public static string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Test");

		static void Main(string[] args)
		{

			Console.WriteLine("CVS Parser 기능 테스트");
			Console.WriteLine("원하는 기능을 숫자로 입력하세요");
			Console.WriteLine("1 : Save");
			Console.WriteLine("2 : Read");

			var number = int.Parse(Console.ReadLine());
			switch (number)
			{
				case 1:
					Students = CsvService.ReadCSV<Student>($@"{_path}\Students.csv");
					CsvService.WriteCSV<Student>(Students, $@"{_path}\Students2.csv");
					break;
				case 2:
					Students = CsvService.ReadCSV<Student>($@"{_path}\Students.csv");
					break;
				default:
					return;
			}
		}
	}
}
