using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        /*
            给定一个包含 n 个整数的数组 nums 和一个目标值 target，判断 nums 中是否存在四个元素 a，b，c 和 d ，使得 a + b + c + d 的值与 target 相等？找出所有满足条件且不重复的四元组。
            注意：

            答案中不可以包含重复的四元组。

            示例：

            给定数组 nums = [1, 0, -1, 0, -2, 2]，和 target = 0。

            满足要求的四元组集合为：
            [
              [-1,  0, 0, 1],
              [-2, -1, 1, 2],
              [-2,  0, 0, 2]
            ]
         */
        static void Main(string[] args)
        {
            var result = FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {

            var result = new List<IList<int>>();
            int[] num = nums.OrderBy(x => x).ToArray();
            int start, end, temp;
            for (int i = 0; i < num.Length; i++)
            {
                if (i != 0 && num[i] == num[i - 1])
                {
                    continue;
                }

                for (int j = i+1; j < num.Length; j++)
                {
                    if(j!=i+1 && num[j] == num[j - 1])
                    {
                        continue;
                    }

                    var current = num[i] + num[j];
                    start = j + 1;
                    end = num.Length - 1;
                    while (start < end)
                    {
                        if (start != j + 1&& num[start] == num[start - 1])
                        {
                            start++;
                            continue;
                        }

                        temp = num[start] + num[end];

                        if (temp + current ==target)
                        {

                            List<int> list = new List<int>(3);

                            list.Add(num[i]);
                            list.Add(num[j]);

                            list.Add(num[start]);

                            list.Add(num[end]);

                            result.Add(list);

                            start++; end--;
                        }
                        else if (temp+ current > target)
                        {
                            end--;
                        }

                        else
                        {
                            start++;
                        }
                    }
                }
            }
            return result;
        }
    }
}
