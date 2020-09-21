using System;
using System.Linq;

namespace issue33
{
    /*
     * 假设按照升序排序的数组在预先未知的某个点上进行了旋转。

        ( 例如，数组 [0,1,2,4,5,6,7] 可能变为 [4,5,6,7,0,1,2] )。

        搜索一个给定的目标值，如果数组中存在这个目标值，则返回它的索引，否则返回 -1 。

        你可以假设数组中不存在重复的元素。

        你的算法时间复杂度必须是 O(log n) 级别。

        示例 1:

        输入: nums = [4,5,6,7,0,1,2], target = 0
        输出: 4
        示例 2:

        输入: nums = [4,5,6,7,0,1,2], target = 3
        输出: -1
     */
    class Program
    {
        static void Main(string[] args)
        {
            var result = Search(new int[] { 1}, 1);
            Console.WriteLine(result);
        }

        public static int Search(int[] nums, int target)
        {
            
            var numList = nums.ToList();
            return numList.IndexOf(target);
        }

        public static int Search1(int[] nums, int target)
        {
            int start = 0;
            int length = nums.Length - 1;

            while (start <= length)
            {
                if (nums[start] == target)
                {
                    return start;
                }
                else if (nums[length] == target)
                {
                    return length;
                }
                start++;
                length--;
            }
            return -1;
        }

        public static int Search2(int[]nums,int target)
        {
            if (nums.Length == 0) return -1;

            for(var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
