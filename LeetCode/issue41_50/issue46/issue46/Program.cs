using System;
using System.Collections.Generic;

namespace issue46
{
    class Program
    {
        /*
         * 给定一个 没有重复 数字的序列，返回其所有可能的全排列。

            示例:

            输入: [1,2,3,4]
            输出:
            [
              [1,2,3,4],
              [1,2,4,3],
              [1,3,2,4],
              [1,3,4,2],
              [1,4,3,2],
              [1,4,2,3],
            ]
         */
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 3 };
            var result = Permute(array);

            Console.WriteLine("a");
        }
        public static IList<IList<int>> Permute(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length == 0)
            {
                return result;
            }
            if (nums.Length == 1)
            {
                result.Add(new List<int>() { nums[0] });
                return result;
            }

            perm(nums, 0, nums.Length - 1);

            void perm(int[] list, int i, int n)
            {
                int j;

                if (i == n)
                {
                    result.Add(new List<int>(list));
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
            void SWAP(ref int a, ref int b)
            {
                int c = a;
                a = b;
                b = c;
            }

            return result;
        }

        public static IList<IList<int>> Permute1(int[] nums)
        {
            var result = new List<IList<int>>();
            if (nums.Length == 0)
            {
                return result;
            }
            if (nums.Length == 1)
            {
                result.Add(new List<int>() { nums[0] });
                return result;
            }
            var numsLength = nums.Length;

            var count = 1;
            while (numsLength > 0)
            {
                count *= numsLength;
                numsLength--;
            }

            for (var i = 0; i < count; i++)
            {
                var time = count / nums.Length;
                result.Add(new List<int>() { i / time });
            }


            return result;
        }
    }
}
