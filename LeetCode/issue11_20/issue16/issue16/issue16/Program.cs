using System;
using System.Collections.Generic;
using System.Linq;

namespace issue16
{
    /// <summary>
    /// 给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。假定每组输入只存在唯一答案。
    /// </summary>
    class Program
    {

        static void Main()
        {
            var list = new List<int> { 0, 2, 1, -3 };
            var target = 1;

            var result = threeSumClosest(list.ToArray(), target);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        //my
        public static int threeSumClosest(int[] nums, int target)
        {
            var myNums = nums.ToList();
            if (myNums.Count < 4)
            {
                return nums.Sum();
            }

            myNums.Sort();
            var numLength = nums.Length;
            var sum = 0;
            var sumResult = myNums[0] + myNums[1] + myNums[2];
            var result = int.MaxValue;

            for (var i = 0; i < numLength - 2; i++)
            {
                var add1 = myNums[i];
                if (add1 > target && add1 > 0)
                {
                    break;
                }
                var tempResult = 0;
                for (var j = i + 1; j < numLength - 1; j++)
                {
                    var add2 = myNums[j];
                    for (var k = i + 2; k < numLength; k++)
                    {
                        var add3 = myNums[k];
                        sum = add1 + add2 + add3;
                        if (sum > target)
                        {
                            tempResult = sum - target;
                        }
                        else
                        {
                            tempResult = target - sum;
                        }
                        if (tempResult < result)
                        {
                            result = tempResult;
                            sumResult = sum;
                        }
                    }
                }
            }

            return sumResult;
        }


        //best
        //public static int threeSumClosest(int[] nums, int target)
        //{
        //    var myNums = nums.ToList();
        //    if (myNums.Count < 4)
        //    {
        //        return nums.Sum();
        //    }

        //    myNums.Sort();
        //    var numLength = nums.Length;
        //    var result = myNums[0] + myNums[1] + myNums[2];

        //    for(var i=0;i< numLength-2; i++)
        //    {
        //        var secondIndex = i + 1;
        //        var thirdIndex = numLength - 1;

        //        while (secondIndex < thirdIndex)
        //        {
        //            var temp = myNums[i] + myNums[secondIndex] + myNums[thirdIndex];

        //            result = Math.Abs(target - temp) <= Math.Abs(target - result) ? temp : result;
        //            if(temp < target)
        //            {
        //                secondIndex++;
        //            }
        //            else if( temp > target)
        //            {
        //                thirdIndex--;
        //            }
        //            else
        //            {
        //                return target;
        //            }
        //        }
        //    }

        //    return result;
        //}
    }
}
