using System;

namespace issue87
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = new int[] { -1, 0, 0, 3, 3, 3, 0, 0, 0 };

            var nums2 = new int[] { 1,2,2 };
            Merge(nums1, 6, nums2, 3);
        }

        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
            {
                return;
            }            
            for(var i = 0; i < nums2.Length; i++)
            {
                nums1[m + i] = nums2[i];
            }

            Array.Sort(nums1);
        }
    }
}
