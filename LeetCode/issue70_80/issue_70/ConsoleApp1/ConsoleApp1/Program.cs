using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ClimbStairs(45);

            Console.WriteLine(result);
        }

        public static int ClimbStairs(int n)
        {
            if (n <= 3) return n;
            long result = 0;

            var longN = long.Parse(n.ToString());

            //n为偶数
            if(n%2 == 0)
            {
                long halfOfN = long.Parse((n / 2 - 1).ToString());
                for(long i =1;i<= halfOfN; i++)
                {
                    result += GetPossibilityWithTwoItem(i, longN - i * 2);
                }

                result += 2;//全1和全2
            }
            else //n为基数
            {
                long halfOfN = long.Parse(((n -1) / 2).ToString());
                for (long i = 1; i <= halfOfN; i++)
                {
                    result += GetPossibilityWithTwoItem(i, longN - i * 2);
                }
                result += 1; //全1
            }

            return int.Parse(result.ToString());
        }

        /// <summary>
        /// 由2的个数和1的个数可能得到的所有排列组合个数
        /// </summary>
        /// <param name="twoCount"></param>
        /// <param name="oneCount"></param>
        /// <returns></returns>
        public static long GetPossibilityWithTwoItem(long twoCount, long oneCount)
        {
            long result = 0;

            long large = Math.Max(twoCount, oneCount);
            long small = Math.Min(twoCount, oneCount);

            result = GetPermutation(large , small);

            return result;
        }

        /// <summary>
        /// 计算排列组合可能个数
        /// </summary>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static long GetPermutation(long max, long min)
        {
            long result1 = 1;
            long result2 = 1;
            var sum = max + min;

            var temp = min;

            while (temp > 1)
            {
                result2 = result2 * temp;
                temp--;
            }

            var divide = false;
            temp = min;

            while (sum > max)
            {
                result1 = result1 * sum;

                //提前做商来防止数字过大
                if (result1 % temp == 0 && temp >1 && !divide)
                {
                    result1 = result1 / temp;
                    result2 = result2 / temp;
                    temp--;
                }

                //只会执行一次整除
                if (result1 > result2 && result1 %result2 ==0 && !divide)
                {
                    result1 = result1 / result2;
                    divide = true;
                }

                sum--;
            }

            return result1;
        }
    }
}
