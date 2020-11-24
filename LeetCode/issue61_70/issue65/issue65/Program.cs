using System;
using System.Linq;

namespace issue65
{
    class Program
    {
        /*
         * 验证给定的字符串是否可以解释为十进制数字。

            例如:

            "0" => true
            " 0.1 " => true
            "abc" => false
            "1 a" => false
            "2e10" => true
            " -90e3   " => true
            " 1e" => false
            "e3" => false
            " 6e-1" => true
            " 99e2.5 " => false
            "53.5e93" => true
            " --6 " => false
            "-+3" => false
            "95a54e53" => false

            说明: 我们有意将问题陈述地比较模糊。在实现代码之前，你应当事先思考所有可能的情况。这里给出一份可能存在于有效十进制数字中的字符列表：

            数字 0-9
            指数 - "e"
            正/负号 - "+"/"-"
            小数点 - "."
            当然，在输入中，这些字符的上下文也很重要。
         */
        static void Main(string[] args)
        {
            var result = IsNumber(".2e81");
            Console.WriteLine(result);
        }

        public static bool IsNumber(string s)
        {
            var reg = @"^\s*[+-]?(?:\d+|(?=.\d))(?:.\d*)?(?:e[+-]?\d+)?\s*$";
            return System.Text.RegularExpressions.Regex.IsMatch(s, reg);
        }

        public static bool IsNumber1(string s)
        {            
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }
            s = s.Trim();
            //整数
            var reg = @"^[0-9]*$";
            if(System.Text.RegularExpressions.Regex.IsMatch(s, reg))
            {
                return true;
            }

            //小数
            reg = @"^-?(0|(\d+))\.\d+$";
            if (System.Text.RegularExpressions.Regex.IsMatch(s, reg))
            {
                return true;
            }

            //无整数部分的小数 例如 .5  -.6
            reg = @"^[+-]?\.\d+$";
            if (System.Text.RegularExpressions.Regex.IsMatch(s, reg))
            {
                return true;
            }

            //小数部分缺失 例如5.  -7.
            reg = @"^-?\d+\.$";
            if (System.Text.RegularExpressions.Regex.IsMatch(s, reg))
            {
                return true;
            }

            //科学计数
            reg = @"^[+-]?[\d]+([\.][\d]?)?([Ee][+-]?[\d])?$";
            if (System.Text.RegularExpressions.Regex.IsMatch(s, reg))
            {
                return true;
            }

            return false;
        }
    }
}
