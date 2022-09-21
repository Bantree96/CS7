using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            double d = 0.1;
            float f = 0.1f;
            if (d == f)
            {

            }
            else
            {

            }

            
            List<int> array3 = new List<int>() { 1, 3, 4, 5, 6 };
            List<int> array4 = new List<int>() { 1, 2, 4, 7, 3, 6 };
            // array1에 array2가 포함되는지

             
            array3.Sort();
            array4.Sort();
            int count = 0;
            foreach (var item in array4)
            {
                if (array3.Contains(item))
                {
                    count++;
                }
            }
            if (array3.Count == count)
            {

            }

            List < Person > people = new List<Person>
            {
                new Person {Name="Tom", Age=63, Address="Korea"},
                new Person { Name = "Winnie", Age = 40, Address = "Tibet" },
                new Person { Name = "Anders", Age = 47, Address = "Sudan" },
                new Person { Name = "Hans", Age = 25, Address = "Tibet" },
                new Person { Name = "Eureka", Age = 32, Address = "Sudan" },
                new Person { Name = "Hawk", Age = 15, Address = "Korea" }
            };

            List<MainLanguage> language = new List<MainLanguage>
            {
                new MainLanguage { Name = "Anders", Language="Delphi"},
                new MainLanguage { Name = "Anders", Language="C#"},
                new MainLanguage { Name = "Tom", Language="C"},
                new MainLanguage { Name = "Hans", Language="Visual C++"},
                new MainLanguage { Name = "Winnie", Language="Python"}
            };

            // 기본 사용
            var all = from person in people select person;

            foreach(var item in all)
            {
                Console.WriteLine(item);
            }

            // 사람 이름만 따오기
            var nameList = from person in people select person.Name;

            foreach(var item in nameList)
            {
                Console.WriteLine($"이름 : {item}");
            }

            // 익명 타입 사용
            var dateList = from person in people select new { Name = person.Name, Year = DateTime.Now.AddYears(-person.Age).Year };

            Console.WriteLine("익명 사용");
            foreach(var item in dateList)
            {
                Console.WriteLine("{0}, {1}", item.Name,item.Year);
            }

            // where : 검색 조건
            var ageOver30 = from person in people where person.Age > 30 select person;
            
            Console.WriteLine("나이가 30이상인 사람");
            foreach (var item in ageOver30)
            {
                Console.WriteLine(item);
            }

            // orderby : 정렬
            var ageSort = from person in people orderby person.Age select person;

            Console.WriteLine("나이순 정렬");
            foreach(var item in ageSort)
            {
                Console.WriteLine(item);
            }

            // group by : 그룹핑
            var addrGroup = from person in people group person by person.Address;

            Console.WriteLine("지역별 그룹");
            foreach(var itemGroup in addrGroup)
            {
                Console.WriteLine($"{itemGroup.Key}");
                foreach(var item in itemGroup)
                {
                    Console.WriteLine($"{item}");
                }
                Console.WriteLine();
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1} in {2}", Name, Age, Address);
        }
    }

    class MainLanguage
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }
}
