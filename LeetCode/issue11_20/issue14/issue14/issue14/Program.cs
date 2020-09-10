using System;
using System.Linq;

namespace issue14
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            if (strs.Length == 1)
            {
                return strs[0];
            }

            var shortestStr = GetShortestStr(strs);
            var tempStr = shortestStr;
            while (tempStr.Length > 0)
            {
                bool isStart = true;
                foreach (var str in strs)
                {
                    if (!str.StartsWith(tempStr))
                    {
                        isStart = false;
                        break;
                    }
                }
                if (isStart)
                {
                    break;
                }
                else
                {
                    tempStr = tempStr.Substring(0, tempStr.Length - 1);
                }
            }

            return tempStr;
        }

        public static string GetShortestStr(string[] strs)
        {
            return strs.OrderBy(m => m.Length).First();
        }
    }
}
