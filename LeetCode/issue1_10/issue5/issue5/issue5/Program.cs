using System;

namespace issue5
{
    class Program
    {
        /*
            给定一个字符串 s，找到 s 中最长的回文子串。你可以假设 s 的最大长度为 1000。

            示例 1：

            输入: "babad"
            输出: "bab"
            注意: "aba" 也是一个有效答案。
            示例 2：

            输入: "cbbd"
            输出: "bb"
*/
        static void Main(string[] args)
        {
            var result = LongestPalindrome("aaabaaa");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string LongestPalindrome(string s)
        {
            var tempStr = s;

            for(var i = 0; i < s.Length; i++)
            {
                var current = s[i];
                tempStr = tempStr.Substring(i);
            }

            return tempStr;
        }
    }
}
