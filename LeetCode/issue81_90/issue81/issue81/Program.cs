using System;
using System.Linq;

namespace issue81
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[]
            {
                1,3
            };
            var target = 1;
            var start = DateTime.Now;
            var result = Search1(nums, target);
            Console.WriteLine((DateTime.Now - start).TotalSeconds);
        }

        public static bool Search(int[] nums, int target)
        {
            return nums.Any(e => e == target);
        }

        public static bool Search1(int[] nums, int target)
        {
            int index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    index = i - 1;
                    break;
                }
            }

            return Find(0, index, nums, target) || Find(index + 1, nums.Length - 1, nums, target);
        }

        private static bool Find(int start, int end, int[] nums, int target)
        {
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target)
                {
                    return true;
                }
                else if (nums[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return false;
        }
    }
}
