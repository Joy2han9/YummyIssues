using System;

namespace issue1
{
    /*给定一个整数数组 nums和一个目标值 target，请你在该数组中找出和为目标值的那 两个整数，并返回他们的数组下标。

    你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。

    示例:

    给定 nums = [2, 7, 11, 15], target = 9

    因为 nums[0] + nums[1] = 2 + 7 = 9
    所以返回[0, 1]*/
    class Program
    {
        static void Main(string[] args)
        {
            TwoSum1(new int[] { 3, 3 }, 6);
        }

        /// <summary>
        /// 通过基本的两层循环来作答
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            throw new Exception("no result");
        }

        /// <summary>
        /// 通过一层循环来作答
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum1(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length - 1; i++)
            {
                var numA = nums[i];
                var numB = target - numA;
                var j = Array.LastIndexOf(nums, numB);
                if (j != i && j != -1)
                {
                    return new[] { i, j };
                }
            }

            throw new Exception("no result");
        }
    }
}
