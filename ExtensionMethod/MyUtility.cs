using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    internal class MyUtility
    {
        public static int GetCount(string message, char[] separators)
        {
            string[] words = message.Split(separators);
            return words.Length;
        }
    }
}
