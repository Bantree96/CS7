﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser.Services
{
	public static class CsvService
	{
		private static readonly object _lock = new object();

		public static void SaveToCSV<T>(List<T> items, string filePath)
		{
			try
			{
				var type = typeof(T);
				var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

				lock (_lock)
				{
					using (StreamWriter writer = new StreamWriter(filePath, append: true))
					{
						// 파일이 비어 있으면 헤더를 작성
						if (writer.BaseStream.Length == 0)
						{
							writer.WriteLine(string.Join(",", properties.Select(p => p.Name)));
						}

						// 데이터 작성
						foreach (var item in items)
						{
							var values = properties.Select(p => p.GetValue(item)?.ToString() ?? string.Empty);
							writer.WriteLine(string.Join(",", values));
						}

						writer.Flush();
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static List<T> ReadCSV<T>(string filepath) where T : new()
		{

			List<T> list = new List<T>();

			try
			{
				if (!File.Exists(filepath)) { throw new FileNotFoundException(); }

				using (var reader = new StreamReader(filepath))
				{

					// 첫 번째 줄 Header
					reader.ReadLine();

					// 데이터 읽기
					while (!reader.EndOfStream)
					{
						string line = reader.ReadLine();
						string[] values = line.Split(',');

						T data = new T();
						var properties = typeof(T).GetProperties();
						for (int i = 0; i < properties.Length; i++)
						{
							var propertyType = properties[i].PropertyType;

							if (propertyType.IsEnum)
							{
								properties[i].SetValue(data, Enum.Parse(propertyType, values[i]));
							}
							else
							{
								properties[i].SetValue(data, Convert.ChangeType(values[i], properties[i].PropertyType));

							}
						}

						list.Add(data);
					}
				}
				return list;
			}
			catch (Exception)
			{
				throw;
			}



		}
	}
}
