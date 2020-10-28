using System;

namespace issue48
{
    class Program
    {
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
