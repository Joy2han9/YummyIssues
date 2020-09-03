using System;
using System.Linq;

namespace issue4
{
    class Program
    {
        /*
        给定两个大小为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。

        请你找出这两个正序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

        你可以假设 nums1 和 nums2 不会同时为空。 

        示例 1:

        nums1 = [1, 3]
        nums2 = [2]

        则中位数是 2.0
        示例 2:

        nums1 = [1, 2]
        nums2 = [3, 4]

        则中位数是 (2 + 3)/2 = 2.5
         */
        static void Main(string[] args)
        {
            
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var count = nums1.Length + nums2.Length;
            var results = nums1.Concat(nums2).OrderBy(m => m).ToArray();
            if (count % 2 == 0)
            {
                var lenthsTotal = (count / 2) - 1;
                return (Convert.ToDouble(results[lenthsTotal]) +
                        Convert.ToDouble(results[lenthsTotal + 1])) / 2;
            }
            else
            {
                var lenthsTotal = (count / 2);

                return results[lenthsTotal];
            }

        }
    }
}
