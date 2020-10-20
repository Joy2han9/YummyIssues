using System;
using System.Collections.Generic;
using System.Linq;

namespace issue44
{
    class Program
    {
        /*
         * 给定一个字符串 (s) 和一个字符模式 (p) ，实现一个支持 '?' 和 '*' 的通配符匹配。

            '?' 可以匹配任何单个字符。
            '*' 可以匹配任意字符串（包括空字符串）。
            两个字符串完全匹配才算匹配成功。

            说明:

            s 可能为空，且只包含从 a-z 的小写字母。
            p 可能为空，且只包含从 a-z 的小写字母，以及字符 ? 和 *。
            示例 1:

            输入:
            s = "aa"
            p = "a"
            输出: false
            解释: "a" 无法匹配 "aa" 整个字符串。
            示例 2:

            输入:
            s = "aa"
            p = "*"
            输出: true
            解释: '*' 可以匹配任意字符串。
            示例 3:

            输入:
            s = "cb"
            p = "?a"
            输出: false
            解释: '?' 可以匹配 'c', 但第二个 'a' 无法匹配 'b'。
            示例 4:

            输入:
            s = "adceb"
            p = "*a*b"
            输出: true
            解释: 第一个 '*' 可以匹配空字符串, 第二个 '*' 可以匹配字符串 "dce".
            示例 5:

            输入:
            s = "acdcb"
            p = "a*c?b"
            输出: false
         */
        static void Main(string[] args)
        {
            var result = IsMatch("abcabcabcabcasdjfkpwqueirjsdakfllkabcdede", "abc*abcabc*a?c*e");
            Console.WriteLine(result);
        }

        public static bool IsMatch(string s, string p)
        {
            int sLength = s.Length;
            int pLength = p.Length;
            int sIndex = 0;
            int pIndex = 0;
            int start = -1;
            int match = 0;
            while (sIndex < sLength)
            {
                if (pIndex < pLength && (s[sIndex]== p[pIndex] || p[pIndex] == '?'))
                {
                    sIndex++;
                    pIndex++;
                }
                else if (pIndex < pLength && p[pIndex] == '*')
                {
                    start = pIndex;
                    match = sIndex;
                    pIndex++;
                }
                else if (start != -1)
                {
                    pIndex = start + 1;
                    match++;
                    sIndex = match;
                }
                else
                {
                    return false;
                }
            }
            while (pIndex < pLength)
            {
                if (p[pIndex] != '*') return false;
                pIndex++;
            }
            return true;
        }

        public static bool IsMatch1(string s, string p)
        {
            if (s == "")
            {
                return p == "" || p.All(x => x == '*');
            }
            if (p.IndexOf('*') != -1 && p.Length > s.Length)
            {
                return false;
            }

            var startIndexList = GetSubStringPList(p);
            var sIndex = 0;
            var pIndex = 0;

            for (; pIndex < startIndexList.Count; pIndex++)
            {
                var current = startIndexList[pIndex];
                if (current == "*")
                {
                    if (pIndex == startIndexList.Count - 1)
                    {
                        return true;
                    }
                    var next = startIndexList[pIndex + 1];
                    while (sIndex + next.Length <= s.Length)
                    {
                        if (Equal(s.Substring(sIndex, next.Length), next))
                        {
                            sIndex += next.Length;
                            pIndex++;
                            break;
                        }
                        else
                        {
                            sIndex++;
                        }
                    }
                }
                else
                {
                    if (Equal(s.Substring(sIndex, current.Length), current))
                    {
                        sIndex += current.Length;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return sIndex == s.Length && pIndex == startIndexList.Count;
        }

        public static bool Equal(string a, string b)
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (b[i] == '?')
                {
                    continue;
                }
                else if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static List<string> GetSubStringPList(string p)
        {
            var result = new List<string>();
            var pSplitByStart = p.Split('*');

            for (var i = 0; i < pSplitByStart.Length - 1; i++)
            {
                if (pSplitByStart[i] != "")
                {
                    result.Add(pSplitByStart[i]);
                }
                result.Add("*");
            }

            if (pSplitByStart[pSplitByStart.Length - 1] != "")
            {
                result.Add(pSplitByStart[pSplitByStart.Length - 1]);
            }

            return result;
        }
    }
}
