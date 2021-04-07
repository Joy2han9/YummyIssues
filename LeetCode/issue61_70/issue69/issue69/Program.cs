using System;
using System.Collections.Generic;

namespace issue69
{
    class Program
    {
        /*
         * 实现 int sqrt(int x) 函数。

计算并返回 x 的平方根，其中 x 是非负整数。

由于返回类型是整数，结果只保留整数的部分，小数部分将被舍去。

示例 1:

输入: 4
输出: 2
示例 2:

输入: 8
输出: 2
说明: 8 的平方根是 2.82842..., 
     由于返回类型是整数，小数部分将被舍去。
         */
        static void Main(string[] args)
        {
            Init();
            var time = DateTime.Now;
            var result = MySqrt1(int.MaxValue);
            var cost = (DateTime.Now - time).TotalMilliseconds;
            
            Console.WriteLine(result);
            Console.WriteLine(cost);

        }

        public static Dictionary<int, int> myDics = new Dictionary<int, int>();

        static public int MySqrt(int x)
        {
            if(x> 2147395600)
            {
                return 46340;
            }

            var result = 0;
            for(var i = 0; i < myDics.Count; i++)
            {
                if (myDics[i] == x)
                {
                    result = i;
                    break;
                }
                else if(myDics[i] > x)
                {
                    result = i-1;
                    break;
                }
            }

            return result;
        }

        static public int MySqrt1(int x)
        {
            if (x == 1)
            {
                return 1;
            }
            int min = 0;
            int max = x;
            while (max - min > 1)
            {
                int mid = (min + max) / 2;
                if (x / mid < mid)
                    max = mid;
                else
                    min = mid;
            }
            return min;
        }

        static public void Init()
        {
            if (myDics.Count == 0)
            {
                for(var i = 0; i <= 46340; i++)
                {
                    myDics.Add(i, i * i);
                }
            }
        }
    }
}
