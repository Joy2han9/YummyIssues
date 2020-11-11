using System;
using System.Collections.Generic;

namespace issue59
{
    class Program
    {
        /*
         * 给定一个正整数 n，生成一个包含 1 到 n2 所有元素，且元素按顺时针顺序螺旋排列的正方形矩阵。

            示例:

            输入: 3
            输出:
            [
             [ 1, 2, 3 ],
             [ 8, 9, 4 ],
             [ 7, 6, 5 ]
            ]
         */
        static void Main(string[] args)
        {
            var result = GenerateMatrix(4);
        }

        public static int[][] GenerateMatrix(int n)
        {
            if (n == 1)
            {
                return new int[][] { new int[] { 1 } };
            }
            if (n == 2)
            {
                return new int[][] { new int[] { 1,2 }, new int[] { 4, 3 }};
            }

            var result = new List<int[]>();
            var step = 1;
            for(var i = 0; i < n; i++)
            {
                var temp = new List<int>();
                for(var j = 0; j < n; j++)
                {
                    temp.Add(0);
                }
                result.Add(temp.ToArray());
            }
            int direction = 0, startX = 1, endX = n, startY = 0, endY = n, currentX = 0, currentY = 0;

            while (step<=n*n)
            {
                switch (direction)
                {
                    case 0:
                        if (currentY < endY)
                        {
                            result[currentX][currentY] = step;
                            currentY++;
                            step++;
                        }
                        else
                        {
                            currentY--;
                            currentX++;
                            endY--;
                            direction++;
                        }
                        break;

                    case 1:
                        if (currentX < endX)
                        {
                            result[currentX][currentY] = step;
                            currentX++;
                            step++;
                        }
                        else
                        {
                            currentX--;
                            currentY--;
                            endX--;
                            direction++;
                        }
                        break;
                    case 2:
                        if (currentY >= startY)
                        {
                            result[currentX][currentY] = step;
                            currentY--;
                            step++;
                        }
                        else
                        {
                            currentY++;
                            currentX--;
                            startY++;
                            direction++;
                        }
                        break;

                    case 3:
                        if (currentX >= startX)
                        {
                            result[currentX][currentY] = step;
                            currentX--;
                            step++;
                        }
                        else
                        {
                            currentX++;
                            currentY++;
                            startX++;
                            direction = 0;

                        }
                        break;
                }
            }

            return result.ToArray();
        }
    }
}
