using System;
using System.Text;

namespace issue43
{
    class Program
    {
        /*
         * 给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。

            示例 1:

            输入: num1 = "2", num2 = "3"
            输出: "6"
            示例 2:

            输入: num1 = "123", num2 = "456"
            输出: "56088"
            说明：

            num1 和 num2 的长度小于110。
            num1 和 num2 只包含数字 0-9。
            num1 和 num2 均不以零开头，除非是数字 0 本身。
            不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。
         */

        static void Main(string[] args)
        {
            var result = Multiply("123", "45");


            Console.WriteLine(result);
        }

        //按照乘法计算过程来结算结果
        public static string Multiply(string num1, string num2)
        {
            if(string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                return "";
            }
            int num1Lenght = num1.Length;
            int num2Lenght = num2.Length;

            //结果可能的长度
            int[] multiples = new int[num1Lenght + num2Lenght];

            for (var i = num1Lenght-1; i >= 0; --i)
            {
                for (int j = num2Lenght-1; j >= 0; --j)
                {
                    //数字字符乘法
                    int mutipleResult = (num1[i] - '0') * (num2[j] - '0');
                    //算进位
                    mutipleResult += multiples[i + j + 1]; 
                    //十位结果
                    multiples[i + j] += mutipleResult / 10;
                    //个位结果
                    multiples[i + j + 1] = mutipleResult % 10;
                }
            }

            StringBuilder sb = new StringBuilder();
            int times = 0;
            //找到数组中第一个非0位置
            while (times < multiples.Length - 1 && multiples[times] == 0)
            {
                times++;
            }
            for (; times < multiples.Length; times++)
            {
                sb.Append(multiples[times]);
            }
            
            return sb.ToString();
        }
    }
}
