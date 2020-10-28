using System;

namespace issue48
{
    class Program
    {
        /*
         给定一个 n × n 的二维矩阵表示一个图像。

            将图像顺时针旋转 90 度。

            说明：

            你必须在原地旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要使用另一个矩阵来旋转图像。

            示例 1:

            给定 matrix = 
            [
              [1,2,3],
              [4,5,6],
              [7,8,9]
            ],

            原地旋转输入矩阵，使其变为:
            [
              [7,4,1],
              [8,5,2],
              [9,6,3]
            ]
            示例 2:

            给定 matrix =
            [
              [ 5, 1, 9,11],
              [ 2, 4, 8,10],
              [13, 3, 6, 7],
              [15,14,12,16]
            ], 

            原地旋转输入矩阵，使其变为:
            [
              [15,13, 2, 5],
              [14, 3, 4, 1],
              [12, 6, 8, 9],
              [16, 7,10,11]
            ]
         */

        static void Main(string[] args)
        {
            var martix = new int[3][];
            martix[0] = new int[3] {1,2,3 };
            martix[1] = new int[3] { 4, 5, 6 };
            martix[2] = new int[3] { 7, 8, 9 };
            Rotate(martix);
        }

        public static void Rotate(int[][] matrix)
        {
            int hang = matrix.Length;
            if (hang == 0) return;
            for (int i = 0; i < hang; i++)
            {
                for (int j = i; j < hang; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
            for (int i = 0; i < hang; i++)
            {
                for (int j = 0; j < hang / 2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][hang - 1 - j];
                    matrix[i][hang - 1 - j] = temp;
                }
            }
        }

        public static void Rotate1(int[][] matrix)
        {
            if (matrix.Length == 1)
            {
                return;
            }

            var length = matrix.Length;
            int[,] copy = new int[length,length];
            for(var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    copy[i, j] = matrix[i][j];
                }
            }
            
            var tempI = 0;
            var tempJ = 0;
            for(var i = 0; i < length; i++)
            {
                for(var j = length - 1; j >= 0; j--)
                {
                    matrix[tempI][tempJ] = copy[j, i];
                    tempJ++;
                }
                tempJ = 0;
                tempI++;
            }

        }
    }
}
