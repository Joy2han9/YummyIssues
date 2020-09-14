using System;
using System.Collections.Generic;

namespace issue22
{
    class Program
    {
        /*
         * 数字 n 代表生成括号的对数，请你设计一个函数，用于能够生成所有可能的并且 有效的 括号组合。

 

            示例：

            输入：n = 3
            输出：[
                   "((()))",
                   "(()())",
                   "(())()",
                   "()(())",
                   "()()()"
                 ]
         */
        static void Main(string[] args)
        {
            var result = GenerateParenthesis(4);

            Console.ReadKey();
        }

        public static IList<string> GenerateParenthesis(int n)
        {
            if (n == 1)
            {
                return new List<string>() { "()" };
            }
            var result = new List<string>();
            BackTrack(result, "", 0, 0, n);

            return result;
        }

        public static void BackTrack(List<string> result, string s, int open, int close, int n)
        {
            if (open + close == 2 * n)
            {
                result.Add(s);
                return;
            }

            if (open < n)
            {
                BackTrack(result, s + "(", open + 1, close, n);
            }
            if (open > close)
            {
                BackTrack(result, s + ")", open, close + 1, n);

            }
        }
    }
}
