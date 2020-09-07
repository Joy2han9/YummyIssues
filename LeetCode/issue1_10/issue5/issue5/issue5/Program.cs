using System;
using System.Linq;

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
            var result = LongestPalindrome("abcdcbabcba");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static string LongestPalindrome(string s)
        {
            var start = 0;
            var maxLength = 0;
            for (var i = 0; i < s.Length; i++)
            {
                var len1 = ExpandAroundCenter(s, i, i);
                var len2 = ExpandAroundCenter(s, i, i + 1);
                var len = Math.Max(len1, len2);
                if (len > maxLength)
                {
                    start = i - (len - 1) / 2;
                    maxLength = len;
                }
            }

            return s.Substring(start, maxLength);
        }

        static int ExpandAroundCenter(string s, int left, int right)
        {
            var i = left;
            var j = right;
            while (i >= 0 && j < s.Length && s[i] == s[j])
            {
                i--;
                j++;
            }

            return j - i - 1;
        }
    }
}
