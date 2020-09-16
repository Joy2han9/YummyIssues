using System;
using System.Linq;

namespace issue27
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2);

            Console.ReadKey();
        }

        public static int RemoveElement(int[] nums, int val)
        {
            var newNums = nums.Where(x => x != val).OrderBy(x=>x).ToArray();
            for (int i = 0; i < newNums.Length; i++)
            {
                nums[i] = newNums[i];
            }

            return newNums.Length;
        }        
    }
}
