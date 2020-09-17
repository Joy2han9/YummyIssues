using System;

namespace issue28
{
    class Program
    {
        /*
         * 实现 strStr() 函数。

            给定一个 haystack 字符串和一个 needle 字符串，在 haystack 字符串中找出 needle 字符串出现的第一个位置 (从0开始)。如果不存在，则返回  -1。

            示例 1:

            输入: haystack = "hello", needle = "ll"
            输出: 2
            示例 2:

            输入: haystack = "aaaaa", needle = "bba"
            输出: -1
            说明:

            当 needle 是空字符串时，我们应当返回什么值呢？这是一个在面试中很好的问题。

            对于本题而言，当 needle 是空字符串时我们应当返回 0 。这与C语言的 strstr() 以及 Java的 indexOf() 定义相符。

         */
        static void Main(string[] args)
        {
            var result = StrStr("mississippi", "pi");

            Console.ReadKey();
        }

        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
            {
                return 0;
            }

            if(haystack.Length==0 && needle.Length != 0)
            {
                return -1;
            }

            if(haystack == needle)
            {
                return 0;
            }

            if(needle.Length == 1){
                for(var i = 0; i < haystack.Length; i++)
                {
                    if(haystack[i] == needle[0])
                    {
                        return i;
                    }
                }
                return -1;
            }            

            var needleLast = needle[needle.Length - 1];

            for (var i = 0; i < haystack.Length - needle.Length+1; i++)
            {
                if (haystack[i] == needle[0] && haystack[i + needle.Length-1] == needleLast)
                {
                    if(haystack.Substring(i,needle.Length) == needle)
                    {
                        return i;
                    }
                }

            }
            return -1;            
        }
    }
}
