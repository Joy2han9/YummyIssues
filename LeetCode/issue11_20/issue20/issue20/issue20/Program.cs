using System;
using System.Collections.Generic;
using System.Linq;

namespace issue20
{
    class Program
    {
        /*
         *给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。

        有效字符串需满足：

        左括号必须用相同类型的右括号闭合。
        左括号必须以正确的顺序闭合。
        注意空字符串可被认为是有效字符串。

        示例 1:

        输入: "()"
        输出: true
        示例 2:

        输入: "()[]{}"
        输出: true
        示例 3:

        输入: "(]"
        输出: false
        示例 4:

        输入: "([)]"
        输出: false
        示例 5:

        输入: "{[]}"
        输出: true
         */
        static void Main(string[] args)
        {
            var result = IsValid("(([]){})");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static bool IsValid(string s)
        {
            if (s.Length % 2 == 1)
            {
                return false;
            }
            if (")]}".Contains(s[0])){
                return false;
            }
            var pair = "()[]{}";
            var leftTag = "([{";
            var myTag = new List<char>();
            for(var i = 0; i < s.Length; i++)
            {
                if(leftTag.Contains(s[i]))
                {
                    myTag.Add(s[i]);

                }
                else
                {
                    if(myTag.Count == 0)
                    {
                        return false;
                    }
                    var last = myTag.Last();
                    if(pair.Contains(last.ToString() + s[i].ToString()))
                    {
                        myTag.RemoveAt(myTag.Count - 1);
                    }
                    else
                    {
                        return false;
                    }
                }                
            }
            return myTag.Count == 0;
        }
    }
}
