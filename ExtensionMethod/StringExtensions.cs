using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    internal static class StringExtensions
    {
        public static string Reverse(this string str)
        {
            StringBuilder sb = new StringBuilder(str.Length);

            for(int i = str.Length - 1; i >= 0; i--)
            {
                sb.Append(str[i]);
            }
            return sb.ToString();
        }

        public static string Reverse(this string str, int start,  int end)
        {
            if (start < 0 || end > str.Length || start > end - 1)
            {
                return str;
            }
            
            StringBuilder sb = new StringBuilder(str.Length);

            // 첫 글자부터 start까지 정상 출력
            for (int i = 0; i < start; i++)
            {
                sb.Append(str[i]);
            }

            // start부터 end까지 뒤집어서 출력
            for(int i = end -1; i >= start; i--)
            {
                sb.Append(str[i]);
            }

            // end부터 끝 까지 정상 출력
            for(int i = end; i < str.Length; i++)
            {
                sb.Append(str[i]);
            }

            return sb.ToString();
        }
    }
}
