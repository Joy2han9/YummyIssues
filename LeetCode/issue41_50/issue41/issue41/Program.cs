using System;
using System.Linq;

namespace issue41
{
    class Program
    {
        /*
         * 给你一个未排序的整数数组，请你找出其中没有出现的最小的正整数。
            示例 1:

            输入: [1,2,0]
            输出: 3
            示例 2:

            输入: [3,4,-1,1]
            输出: 2
            示例 3:

            输入: [7,8,9,11,12]
            输出: 1
         */
        static void Main(string[] args)
        {
            var result = FirstMissingPositive(new int[] { 0, 2, 2, 1, 1 });

            Console.WriteLine(result);
        }

        public static int FirstMissingPositive(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 1;
            }           

            var numList = nums.OrderBy(x => x).Where(x => x > 0).Distinct().ToList();
            if (!numList.Any() || numList[0] != 1)
            {
                return 1;
            }

            var temp = 1;
            for(var i = 0; i < numList.Count; i++)
            {
                if (temp != numList[i])
                {
                    return temp;
                }
                temp++;
            }

            return numList.Last()+1;
        }
    }
}
