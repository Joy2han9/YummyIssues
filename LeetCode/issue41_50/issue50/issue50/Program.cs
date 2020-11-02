using System;

namespace issue50
{
    class Program
    {
        /*
         * 实现 pow(x, n) ，即计算 x 的 n 次幂函数。

            示例 1:

            输入: 2.00000, 10
            输出: 1024.00000
            示例 2:

            输入: 2.10000, 3
            输出: 9.26100
            示例 3:

            输入: 2.00000, -2
            输出: 0.25000
            解释: 2-2 = 1/22 = 1/4 = 0.25
            说明:

            -100.0 < x < 100.0
            n 是 32 位有符号整数，其数值范围是 [−231, 231 − 1] 。
         */
        static void Main(string[] args)
        {
            var result = MyPow(2.00000, -2);
        }

        public static double MyPow(double x, int n)
        {
            var result = 0d;
            if (x == 1.0) return x;
            if (n == -1) return 1 / x;
            if (n == 0) return 1;
            if (n == 1) return x;
            if (n < -1) return 1 / (MyPow(x, -(n + 1)) * x);    //针对n为int.minValue的情况

            if (n % 2 == 0)
            {
                result = MyPow(x * x, n / 2);
            }
            else
            {
                result = MyPow(x * x, n / 2) * x;
            }

            return result;
        }
    }
}
