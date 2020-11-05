using System;
using System.Collections.Generic;
using System.Linq;

namespace issue54
{
    class Program
    {
        /*
         给定一个包含 m x n 个元素的矩阵（m 行, n 列），请按照顺时针螺旋顺序，返回矩阵中的所有元素。

            示例 1:

            输入:
            [
             [ 1, 2, 3 ],
             [ 4, 5, 6 ],
             [ 7, 8, 9 ]
            ]
            输出: [1,2,3,6,9,8,7,4,5]
            示例 2:

            输入:
            [
              [1, 2, 3, 4],
              [5, 6, 7, 8],
              [9,10,11,12]
            ]
            输出: [1,2,3,4,8,12,11,10,9,5,6,7]
         */
        static void Main(string[] args)
        {
            var matrix = new int[][]
            {
                
            };
            var result = SpiralOrder(matrix);
            
        }

        public static IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return new List<int>();
            }
            if (matrix.Length == 1)
            {
                return matrix[0].ToList();
            }
            int direction = 0, startX = 1, endX = matrix.Length, startY = 0, endY = matrix[0].Length, currentX = 0, currentY = 0;
            var result = new List<int>();
            var step = 0;
            
            while (step < matrix.Length * matrix[0].Length)
            {
                switch (direction)
                {
                    case 0:
                        if (currentY < endY)
                        {
                            result.Add(matrix[currentX][currentY]);
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
                            result.Add(matrix[currentX][currentY]);
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
                            result.Add(matrix[currentX][currentY]);
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
                            result.Add(matrix[currentX][currentY]);
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

            return result;
        }
    }
}
