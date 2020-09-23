using System;
using System.Linq;

namespace issue34
{
    class Program
    {
        /*
         * 给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。

            你的算法时间复杂度必须是 O(log n) 级别。

            如果数组中不存在目标值，返回 [-1, -1]。

            示例 1:

            输入: nums = [5,7,7,8,8,10], target = 8
            输出: [3,4]
            示例 2:

            输入: nums = [5,7,7,8,8,10], target = 6
            输出: [-1,-1]
         */
        static void Main(string[] args)
        {
            var result = SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6);

            Console.ReadKey();
        }

        public static int[] SearchRange(int[] nums, int target)
        {
            var result = new int[] { -1, -1 };
            var numList = nums.ToList();
            var firstIndex = numList.IndexOf(target);

            if (firstIndex != -1)
            {
                var lastIndex = numList.LastIndexOf(target);
                result[0] = firstIndex;
                result[1] = lastIndex;
            }

            return result;
        }
    }
}
