using System;

namespace issue67
{
    class Program
    {
        /*
         * 给你两个二进制字符串，返回它们的和（用二进制表示）。

            输入为 非空 字符串且只包含数字 1 和 0。

 

            示例 1:

            输入: a = "11", b = "1"
            输出: "100"
            示例 2:

            输入: a = "1010", b = "1011"
            输出: "10101"
 

            提示：

            每个字符串仅由字符 '0' 或 '1' 组成。
            1 <= a.length, b.length <= 10^4
            字符串如果不是 "0" ，就都不含前导零。
         */
        static void Main(string[] args)
        {
            var result = AddBinary("11101", "111110");
        }

        public static string AddBinary(string a, string b)
        {
            var result = string.Empty;
            var lengthA = a.Length - 1;
            var lengthB = b.Length - 1;

            var plus = 0;
            while (lengthA >= 0 && lengthB >= 0)
            {
                var currentA = a[lengthA] - '0';
                var currentB = b[lengthB] - '0';
                var current = currentA + currentB + plus;
                if (current >= 2)
                {
                    result = current % 2 + result;
                    plus = 1;
                }
                else
                {
                    result = current + result;
                    plus = 0;
                }
                lengthA--;
                lengthB--;
            }
            if (lengthA == lengthB)
            {
                if (plus == 1)
                {
                    result = "1" + result;
                }
            }
            else
            {
                if (lengthA > lengthB)
                {
                   result = HandleString(a, result, lengthA,plus);
                }
                else
                {
                   result = HandleString(b, result, lengthB,plus);
                }
            }

            return result;
        }

        public static string HandleString(string input, string result, int index,int plus)
        {
            while (index>=0)
            {
                var current = input[index] - '0' + plus;
                if (current >= 2)
                {
                    result = current % 2 + result;
                    plus = 1;
                }
                else
                {
                    result = current + result;
                    plus = 0;
                }
                index--;
            }

            if (plus == 1)
            {
                result = "1" + result;
            }

            return result;
        }
    }
}
