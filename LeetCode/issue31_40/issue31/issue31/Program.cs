using System;
using System.Collections.Generic;
using System.Linq;

namespace issue31
{
    class Program
    {
        /*
         * 实现获取下一个排列的函数，算法需要将给定数字序列重新排列成字典序中下一个更大的排列。

            如果不存在下一个更大的排列，则将数字重新排列成最小的排列（即升序排列）。

            必须原地修改，只允许使用额外常数空间。

            以下是一些例子，输入位于左侧列，其相应输出位于右侧列。
            1,2,3 → 1,3,2
            3,2,1 → 1,2,3
            1,1,5 → 1,5,1
         */
        static void Main(string[] args)
        {
            NextPermutation(new int[] { 5,4,7, 5, 3, 2 });

            Console.ReadKey();
        }

        public static void NextPermutation(int[] nums)
        {
            var newNums = new List<int>();

            var myList = nums.ToList();
            var index = 0;
            var change = 0;
            while (myList.Any())
            {
                if (!CompareArray(nums,myList.OrderByDescending(x=>x).ToArray()))
                {
                    newNums.Add(myList[0]);
                    myList.RemoveAt(0);
                    index++;
                }
                else if (newNums.Any())
                {
                    myList.Sort();
                    for (var i = 0; i < myList.Count; i++)
                    {
                        if (myList[i] > newNums[newNums.Count - 1])
                        {
                            change = myList[i];
                            myList[i] = newNums[newNums.Count - 1];
                            myList.Sort();
                            break;
                        }
                    }
                    newNums[newNums.Count - 1] = change;
                    newNums.AddRange(myList);
                    for (var i = 0; i < newNums.Count; i++)
                    {
                        nums[i] = newNums[i];
                    }
                    break;
                }
                else
                {
                    for(var i = 0; i < nums.Length; i++)
                    {
                        nums[i] = myList[nums.Length-1-i];
                    }

                    break;
                }
            }
        }

        public static bool CompareArray(int[] array1, int[] array2)
        {
            for (var i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }
            return true;
        }
    }
}
