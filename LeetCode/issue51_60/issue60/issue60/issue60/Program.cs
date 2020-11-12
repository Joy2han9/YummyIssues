using System;
using System.Collections.Generic;
using System.Linq;

namespace issue60
{
    class Program
    {
        /*
         * 给出集合 [1,2,3,...,n]，其所有元素共有 n! 种排列。

            按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下：

            "123"
            "132"
            "213"
            "231"
            "312"
            "321"
            给定 n 和 k，返回第 k 个排列。

 

            示例 1：

            输入：n = 3, k = 3
            输出："213"
            示例 2：

            输入：n = 4, k = 9
            输出："2314"
            示例 3：

            输入：n = 3, k = 1
            输出："123"
 

            提示：

            1 <= n <= 9
            1 <= k <= n!
         */
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            var result = GetPermutation1(9, 171669);
            Console.WriteLine(DateTime.Now - start);
        }

        public static string GetPermutation(int n, int k)
        {
            int[] factorial = new int[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320 };
            List<char> chs = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string str = "";
            for (--k; n-- != 0; k %= factorial[n])
            {
                int i = k / factorial[n];
                str += chs[i].ToString();
                chs.Remove(chs[i]);
            }
            return str;
        }

        public static string GetPermutation1(int n, int k)
        {
            if (n == 1) return "1";
            var times = 1;
            var charList = new List<char>();
            for (var i = 1; i < n; i++)
            {
                times *= i;
            }
            var firstNum = k / times + 1;
            if (k % times == 0)
            {
                firstNum--;
            }

            for (var i = 1; i <= n; i++)
            {
                if (i != firstNum)
                {
                    charList.Add(char.Parse(i.ToString()));
                }
            }

            var myList = GetStrList(charList.ToArray());
            var index = k % times == 0 ? times - 1 : k % times - 1;

            return firstNum.ToString() + myList[index];
        }

        public static List<string> GetStrList(char[] nums)
        {
            var result = new List<string>();

            perm(nums, 0, nums.Length - 1);

            void perm(char[] list, int i, int n)
            {
                int j;

                if (i == n)
                {
                    result.Add(new string(list));
                }
                else
                {
                    for (j = i; j <= n; j++)
                    {
                        if (i == j)
                        {
                            perm(list, i + 1, n);
                        }
                        else
                        {
                            SWAP(ref list[i], ref list[j]);
                            perm(list, i + 1, n);
                            SWAP(ref list[i], ref list[j]);//数组一定要复原！！！！！                     
                        }
                    }
                }
            }
            void SWAP(ref char a, ref char b)
            {
                char c = a;
                a = b;
                b = c;
            }

            return result.OrderBy(x=>x).ToList();
        }
    }
}
