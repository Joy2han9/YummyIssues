using System;
using System.Linq;

namespace issue53
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MaxSubArray(new int[] { -3,5,-2,6,-8,5,3,7,-3,2 });

            Console.WriteLine(result);
        }

        public static int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                nums[i] = Math.Max(nums[i - 1], 0) + nums[i];
                max = Math.Max(max, nums[i]);
            }
            return max;
        }

        public static int MaxSubArray1(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2)
            {
                if (nums[0] >= 0 && nums[1] >= 0)
                {
                    return nums[0] + nums[1];
                }
                else
                {
                    return Math.Max(nums[0], nums[1]);
                }
            }
            var numList = nums.OrderByDescending(x => x).ToList();
            if (numList[0] <= 0)
            {
                return numList[0];
            }
            var end = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    end = i;
                }
            }
            var maxSum = 0;
            var currentSum = 0;
            while (end >= 0)
            {
                if (nums[end] <= 0)
                {
                    end--;
                    continue;
                }
                currentSum = nums[end];
                maxSum = Math.Max(currentSum, maxSum);
                for (var i = end - 1; i >= 0; i--)
                {
                    if (currentSum + nums[i] > maxSum)
                    {
                        maxSum = currentSum + nums[i];
                    }
                    currentSum += nums[i];
                }
                end--;
            }


            return maxSum;
        }
    }
}
