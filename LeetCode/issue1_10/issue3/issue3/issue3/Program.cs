using System;
using System.Collections.Generic;

namespace issue3
{
    class Program
    {
        /*
        给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
        示例 1:
        输入: "abcabcbb"
        输出: 3 
        解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。

        示例 2:

        输入: "bbbbb"
        输出: 1
        解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
        示例 3:

        输入: "pwwkew"
        输出: 3
        解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
        请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
        */
        static void Main(string[] args)
        {
            var result = LengthOfLongestSubstring2("abcbadefaedfebd");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int LengthOfLongestSubstring(string s)
        {
            var result = "";
            var tempResult = "";
            var index = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (tempResult.IndexOf(s[i]) == -1)
                {
                    tempResult += s[i];
                    if (tempResult.Length > result.Length)
                    {
                        result = tempResult;
                    }
                }
                else
                {
                    if (tempResult.Length > result.Length)
                    {
                        result = tempResult;
                    }
                    index = tempResult.IndexOf(s[i]);
                    tempResult = tempResult.Substring(index + 1) + s[i];
                }
            }
            return result.Length;
        }

        public static int LengthOfLongestSubstring2(string s)
        {
            HashSet<char> letter = new HashSet<char>();
            int left = 0, right = 0;
            int length = s.Length;
            int count = 0, max = 0;
            while (right < length)
            {
                if (!letter.Contains(s[right]))
                {
                    letter.Add(s[right]);
                    right++;
                    count++;
                }
                else
                {
                    letter.Remove(s[left]);
                    left++;
                    count--;
                }
                max = Math.Max(max, count);
            }
            return max;
        }
    }
}
