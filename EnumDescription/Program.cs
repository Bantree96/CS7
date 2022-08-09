using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumDescription
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string banana = MyEnum.Banana.DescriptionAttr();

            Console.WriteLine(banana);
        }

        public static string DescriptionAttr<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }

    public enum MyEnum
    {
        Apple = 1,
        [Description("나는 바나나")]
        Banana = 2,
        [Description("나는 수박")]
        Watermelon = 3
    }
}
