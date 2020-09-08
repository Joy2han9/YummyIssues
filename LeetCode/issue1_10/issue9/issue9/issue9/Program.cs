using System;
using System.Linq;

namespace issue9
{
    class Program
    {
        /*
         判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。

        示例 1:

        输入: 121
        输出: true
        示例 2:

        输入: -121
        输出: false
        解释: 从左向右读, 为 -121 。 从右向左读, 为 121- 。因此它不是一个回文数。
        示例 3:

        输入: 10
        输出: false
        解释: 从右向左读, 为 01 。因此它不是一个回文数。
*/
        static void Main(string[] args)
        {
            var result = IsPalindrome(1233210);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;

            var xStr = x.ToString();
            var xLength = xStr.Length;
            if (xStr[xLength - 1] == '0')
            {
                return false;
            }
            var left = 0;
            var right = xLength - 1;
            while (right > left)
            {
                if (xStr[left] != xStr[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
