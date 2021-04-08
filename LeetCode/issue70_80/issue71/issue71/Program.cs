using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace issue71
{
    class Program
    {
        /*
         * 给你一个字符串 path ，表示指向某一文件或目录的 Unix 风格 绝对路径 （以 '/' 开头），请你将其转化为更加简洁的规范路径。

在 Unix 风格的文件系统中，一个点（.）表示当前目录本身；此外，两个点 （..） 表示将目录切换到上一级（指向父目录）；两者都可以是复杂相对路径的组成部分。任意多个连续的斜杠（即，'//'）都被视为单个斜杠 '/' 。 对于此问题，任何其他格式的点（例如，'...'）均被视为文件/目录名称。

请注意，返回的 规范路径 必须遵循下述格式：

始终以斜杠 '/' 开头。
两个目录名之间必须只有一个斜杠 '/' 。
最后一个目录名（如果存在）不能 以 '/' 结尾。
此外，路径仅包含从根目录到目标文件或目录的路径上的目录（即，不含 '.' 或 '..'）。
返回简化后得到的 规范路径 。
         */
        static void Main(string[] args)
        {
            //var testStr = "//aa//.////bb///..///..////cc////dd///";
            var testStr = "/.../";
            var result = SimplifyPath1(testStr);
            Console.WriteLine(result);
        }

        public static string SimplifyPath(string path)
        {
            path = path.TrimEnd('/').TrimStart('/');
            if (path.Length == 0)
            {
                return "/";
            }
            var stringBuilder = new StringBuilder();
            var current = new Char();
            for(var i = 0; i < path.Length; i++)
            {
                if(current != path[i] || current != '/')
                {
                    stringBuilder.Append(path[i]);
                    current = path[i];
                }                
            }

            var list = stringBuilder.ToString().Split('/');
            var stack = new Stack();
            for (var i = 0; i < list.Length; i++)
            {
                if(list[i] == "..")
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }else if (list[i] == ".")
                {
                    continue;
                }
                else
                {
                    stack.Push(list[i]);
                }
            }
            var result = "";
            if(stack.Count > 0)
            {
                while (stack.Count > 0)
                {
                    result = "/" + stack.Pop() + result;
                }
            }
            else
            {
                result = "/";
            }
            
            
            return result;
        }

        public static string SimplifyPath1(string path)
        {
            Stack<string> s = new Stack<string>();

            string[] spiltArr = path.Split('/');
            for (int i = 0; i < spiltArr.Length; i++)
            {
                if (spiltArr[i] == "")
                {
                    continue;
                }

                if (spiltArr[i] == "..")
                {
                    if (s.Count > 0)
                    {
                        s.Pop();
                    }
                }
                else if (spiltArr[i] != ".")
                {
                    s.Push(spiltArr[i]);
                }
            }

            if (s.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                while (s.Count != 0)
                {
                    sb.Insert(0, s.Pop());
                    sb.Insert(0, "/");
                }
                return sb.ToString();
            }
            else
            {
                return "/";
            }
        }
    }
}
