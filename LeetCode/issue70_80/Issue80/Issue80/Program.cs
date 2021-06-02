using System;

namespace Issue80
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[]
            {
                0, 0, 1, 1, 1, 1, 2, 3, 3
            };
            var start = DateTime.Now;
            var result = RemoveDuplicates(nums);
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
        }

        public static int RemoveDuplicates(int[] nums)
        {
            var diff = 0;
            var sameCount = 1;
            var previous = nums[0];
            for(var i = 1; i < nums.Length; i++)
            {
                if(previous == nums[i])
                {
                    if (++sameCount > 2)
                    {
                        diff++;
                    }
                }
                else
                {
                    previous = nums[i];
                    sameCount = 1;
                }
                nums[i - diff] = nums[i];
            }

            return nums.Length - diff;
        }
    }
}
