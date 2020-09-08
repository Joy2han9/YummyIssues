using System;

namespace issue7
{
    class Program
    {
        /*
         给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。

        示例 1:

        输入: 123
        输出: 321
         示例 2:

        输入: -123
        输出: -321
        示例 3:

        输入: 120
        输出: 21
        注意:

        假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−231,  231 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。
        */
        static void Main(string[] args)
        {
            var result = Reverse(1534236469);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int Reverse(int x)
        {
            bool isMinus = false;

            var temp = x;
            if (temp <= int.MinValue)
            {
                temp -= int.MinValue;
            }

            if (temp >= int.MaxValue)
            {
                temp -= int.MaxValue;
            }

            if (Math.Abs(temp) < 10)
            {
                return temp;
            }

            if (temp < 0)
            {
                temp = 0 - temp;
                isMinus = true;
            }

            var resultStr = GetReverse(temp.ToString());
            var result = 0;
            int.TryParse(resultStr, out result);
            if (isMinus)
            {
                result = 0 - result;
            }

            return result;
        }

        public static string GetReverse(string s)
        {
            var result = new System.Text.StringBuilder();
            for (var i = s.Length - 1; i >= 0; i--)
            {
                result.Append(s[i]);
            }

            return result.ToString();
        }
    }
}
