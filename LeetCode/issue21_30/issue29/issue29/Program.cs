﻿using System;

namespace issue29
{
    class Program
    {
        /*
         * 给定两个整数，被除数 dividend 和除数 divisor。将两数相除，要求不使用乘法、除法和 mod 运算符。

            返回被除数 dividend 除以除数 divisor 得到的商。

            整数除法的结果应当截去（truncate）其小数部分，例如：truncate(8.345) = 8 以及 truncate(-2.7335) = -2

 

            示例 1:

            输入: dividend = 10, divisor = 3
            输出: 3
            解释: 10/3 = truncate(3.33333..) = truncate(3) = 3
            示例 2:

            输入: dividend = 7, divisor = -3
            输出: -2
            解释: 7/-3 = truncate(-2.33333..) = -2
 

            提示：

            被除数和除数均为 32 位有符号整数。
            除数不为 0。
            假设我们的环境只能存储 32 位有符号整数，其数值范围是 [−231,  231 − 1]。本题中，如果除法结果溢出，则返回 231 − 1。

         */
        static void Main(string[] args)
        {
            var result = Divide(-2147483648, -2);
            

            Console.ReadKey();
        }

        //这题可真牛逼，我写的效率太差，只好借鉴大佬的代码，可还是看不懂，难受啊
        public static int Divide(int dividend, int divisor)
        {
            if (dividend == 0)
            {
                return 0;
            }
            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }
            bool negative;
            negative = (dividend ^ divisor) < 0;//用异或来计算是否符号相异
            long dividendL = Math.Abs((long)dividend);
            long divisorL = Math.Abs((long)divisor);
            int result = 0;
            for (int i = 31; i >= 0; i--)
            {
                if ((dividendL >> i) >= divisorL)
                {//找出足够大的数2^n*divisor
                    result += 1 << i;//将结果加上2^n
                    dividendL -= divisorL << i;//将被除数减去2^n*divisor
                }
            }
            return negative ? -result : result;//符号相异取反
        }
    }
}
