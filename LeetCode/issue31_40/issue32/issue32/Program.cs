using System;
using System.Collections.Generic;
using System.Linq;

namespace issue32
{
    class Program
    {
        /*
         * 给定一个只包含 '(' 和 ')' 的字符串，找出最长的包含有效括号的子串的长度。

示例 1:

输入: "(()"
输出: 2
解释: 最长有效括号子串为 "()"
示例 2:

输入: ")()())"
输出: 4
解释: 最长有效括号子串为 "()()"
         */
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            var result = LongestValidParentheses("((())())(()))(()()(()(()))(()((((()))))))((()())()))()()(()(((((()()()())))()())(()()))((((((())))((()))()()))))(()))())))()))()())((()()))))(()(((((())))))()((()(()(())((((())(())((()()(()())))())(()(())()()))())(()()()))()(((()())(((()()())))(((()()()))(()()))()))()))))))())()()((()(())(()))()((()()()((())))()(((()())(()))())())))(((()))))())))()(())))()())))())()((()))((()))()))(((())((()()()(()((()((())))((()()))())(()()(()))))())((())))(()))()))))))()(()))())(()())))))(()))((())(()((())(((((()()()(()()())))(()())()((()(()()))(()(())((()((()))))))))(()(())()())()(()(()(()))()()()(()()())))(())(()((((()()))())))(())((()(())())))))())()()))(((())))())((()(()))(()()))((())(())))))(()(()((()((()()))))))(()()()(()()()(()(())()))()))(((()(())()())(()))())))(((()))())(()((()))(()((()()()(())()(()())()(())(()(()((((())()))(((()()(((()())(()()()(())()())())(()(()()((()))))()(()))))(((())))()()))(()))((()))))()()))))((((()(())()()()((()))((()))())())(()((()()())))))))()))(((()))))))(()())))(((()))((()))())))(((()(((())))())(()))))(((()(((((((((((((())(((()))((((())())()))())((((())(((())))())(((()))))()())()(())())(()))))()))()()()))(((((())()()((()))())(()))()()(()()))(())(()()))()))))(((())))))((()()(()()()()((())((((())())))))((((((()((()((())())(()((()))(()())())())(()(())(())(()((())((())))(())())))(()()())((((()))))((()(())(()(()())))))))))((()())()()))((()(((()((()))(((((()()()()()(()(()((()(()))(()(()((()()))))()(()()((((((()((()())()))((())()()(((((()(()))))()()((()())((()())()(())((()))()()(()))");
            var end = DateTime.Now;
            Console.WriteLine((start - end).ToString());
            Console.WriteLine(result);
            Console.ReadKey();
        }

        //思考：        
        //最初的)无意义
        //最后面的(无意义
        //符合的字串一定左右个数相同
        //符合的字符串一定包含()
        public static int LongestValidParentheses(string s)
        {            
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            if(s.IndexOf("(")==-1 || s.IndexOf(")") == -1)
            {
                return 0;
            }
            s = s.Substring(s.IndexOf("("));    //最开始的所有)无意义
            s = s.Substring(0, s.LastIndexOf(")") + 1); //结尾的(无意义
            var countOfRight = s.Length - s.Replace(")", "").Length;
            var result = 0;            
            for(var i = 0; i < s.Length; i++)
            {
                var right = s.Length;
                if (result >= right - i) break;

                while (i < right)
                {
                    if (i == right || result >= right - i) break;
                    if ((right - i) % 2 == 1)
                    {
                        right--;
                        continue;
                    }
                    var tempStr = s.Substring(i, right - i);
                    
                    if (tempStr.Count(x => x == '(') == tempStr.Length / 2)
                    {
                        var success = validStr(tempStr);

                        if (success && result < tempStr.Length)
                        {
                            result = tempStr.Length;
                            break;
                        }
                        else
                        {
                            right -= 2;
                        }
                    }
                    else
                    {
                        right-=2;
                    }
                }
            }
            return result;
        }

        //通过栈的方式实现，效率高很多
        public static int LongestValidParentheses1(string s)
        {
            int result = 0;
            var stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (!stack.Any())
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        result = Math.Max(result, i - stack.Peek());
                    }
                }

            }
            return result;
        }

        public static bool validStr(string s)
        {
            var previousLength = s.Length;
            var currentLength = s.Length;
            var temp = s;
            while (temp.Length > 0)
            {
                temp = ReplaceTag(temp);
                currentLength = temp.Length;
                if (previousLength != currentLength)
                {
                    previousLength = currentLength;
                }
                else
                {
                    break;
                }

            }

            return temp.Length == 0;
        }

        public static string ReplaceTag(string s)
        {
            s = s.Replace("()", "");

            return s;
        }
    }
}
