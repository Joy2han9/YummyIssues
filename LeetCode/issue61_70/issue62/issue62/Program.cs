using System;

namespace issue62
{
    class Program
    {
        /*
         * 机器人每次只能向下或者向右移动一步。机器人试图达到网格的右下角（在下图中标记为“Finish”）。

            问总共有多少条不同的路径？



            例如，上图是一个7 x 3 的网格。有多少可能的路径？

 

            示例 1:

            输入: m = 3, n = 2
            输出: 3
            解释:
            从左上角开始，总共有 3 条路径可以到达右下角。
            1. 向右 -> 向右 -> 向下
            2. 向右 -> 向下 -> 向右
            3. 向下 -> 向右 -> 向右
            示例 2:

            输入: m = 7, n = 3
            输出: 28
 

            提示：

            1 <= m, n <= 100
            题目数据保证答案小于等于 2 * 10 ^ 9
         */
        static int[,] myArray = new int[101, 101];
        static void Main(string[] args)
        {
            init();
            var result = UniquePaths(100,100);
        }

        public static int UniquePaths(int m, int n)
        {
            return myArray[m, n];
        }

        public static void init()
        {
            for (var i = 1; i <= 100; i++)
            {
                myArray[1, i] = 1;
                myArray[i, 1] = 1;
            }

            for (var i = 2; i <= 100; i++)
            {
                for (var j = 2; j <= 100; j++)
                {
                    myArray[i, j] = myArray[i - 1, j] + myArray[i ,j-1];
                }
            }
        }
    }
}
