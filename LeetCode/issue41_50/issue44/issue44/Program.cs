using System;
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
            var result = IsMatch("abcabczzzde", "*abc???de*");
            Console.WriteLine(result);
        }

        public static bool IsMatch(string s, string p)
        {
            if (s=="")
            {
                return p == "" || p.All(x => x == '*');
            }
            if(p.IndexOf('x')==-1 && p.Length > s.Length)
            {
                return false;
            }

            var tempS = s;
            var result = true;
            var indexS = 0;
            for(var i = 0; i < p.Length; i++)
            {
                var currentP = p[i];
                if(currentP == '*')
                {
                    if (i == p.Length - 1)
                    {
                        return true;
                    }
                    else if (i + 1 < p.Length)
                    {
                        tempS = s.Substring(indexS);
                        indexS = tempS.IndexOf(p[i + 1]) + s.Length - tempS.Length;
                    }
                }
                else if (currentP == '?' || currentP == s[indexS])
                {
                    indexS++;
                    if(indexS > s.Length)
                    {
                        return false;
                    }
                    continue;
                }
                else
                {
                    return false;
                }
            }

            result = indexS == s.Length;

            return result;
        }
    }
}
