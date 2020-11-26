using System;
using System.Linq;

namespace issue66
{
    class Program
    {
        /*
         * 给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一。

            最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。

            你可以假设除了整数 0 之外，这个整数不会以零开头。

 

            示例 1：

            输入：digits = [1,2,3]
            输出：[1,2,4]
            解释：输入数组表示数字 123。
            示例 2：

            输入：digits = [4,3,2,1]
            输出：[4,3,2,2]
            解释：输入数组表示数字 4321。
            示例 3：

            输入：digits = [0]
            输出：[1]
 

            提示：

            1 <= digits.length <= 100
            0 <= digits[i] <= 9
         */
        static void Main(string[] args)
        {
            var digits = new int[] { 0 };

            var result = PlusOne(digits);            
        }

        public static int[] PlusOne(int[] digits)
        {
            var myList = digits.ToList();
            var plus = true;
            for(var i = myList.Count - 1; i >= 0; i--)
            {
                if (plus == true)
                {
                    if (myList[i] == 9)
                    {
                        myList[i] = 0;                        
                    }
                    else
                    {
                        myList[i]++;
                        plus = false;
                        break;
                    }
                }                
            }
            if (plus)
            {
                myList.Insert(0, 1);
            }

            return myList.ToArray();
        }
    }
}
