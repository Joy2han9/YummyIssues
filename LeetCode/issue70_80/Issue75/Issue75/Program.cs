using System;
using System.Linq;

namespace Issue75
{
    class Program
    {
        static void Main(string[] args)
        {
            var myArray = new int[] { 2,2,2,2,2,1,2,1,2,1 };
            DateTime d1 = DateTime.Now;
            SortColors2(myArray);
            Console.WriteLine((DateTime.Now - d1).TotalMilliseconds);
        }

        public static void SortColors(int[] nums)
        {
            int zeroCount=0, oneCount=0, twoCount=0;
            zeroCount = nums.Count(x => x == 0);
            oneCount = nums.Count(x => x == 1);
            twoCount = nums.Count(x => x == 2);
          
            for (var i = 0; i < nums.Length; i++)
            {
                if (i<zeroCount)
                {
                    nums[i] = 0;
                    continue;
                }

                if (i>=zeroCount && i< zeroCount + oneCount)
                {
                    nums[i] = 1;
                    continue;
                }

                if (i>= zeroCount + oneCount && i <nums.Length)
                {
                    nums[i] = 2;
                    continue;
                }
            }
        }

        public static void SortColors1(int[] nums)
        {
            Array.Sort(nums);
        }

        public static void SortColors2(int[] nums)
        {
            int low = 0, high = nums.Length - 1, index = 0, temp;

            while (index <= high)
            {

                if (nums[index] == 0)
                {
                    temp = nums[index];
                    nums[index] = nums[low];
                    nums[low] = temp;
                    low++;
                    index = low;

                }
                else
                {
                    if (nums[index] == 2)
                    {
                        temp = nums[index];
                        nums[index] = nums[high];
                        nums[high] = temp;
                        high--;

                    }
                }
                if (index >= nums.Length - 1) break;
                if (nums[index] == 1) index++;


            }

        }

        
    }
}
