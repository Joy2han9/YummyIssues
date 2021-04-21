using System;
using System.Collections.Generic;
using System.Linq;

namespace issue73
{
    class Program
    {
        static void Main(string[] args) { 
            var matrix = new[]{
                new int []{ 0,1,2,0 },
                new int []{3,4,5,2},
                new int [] {1,3,1,5},
            };

            SetZeroes(matrix);
        }

        public static void SetZeroes(int[][] matrix)
        {
            var row = matrix.Length;
            var col = matrix[0].Length;
            var rowList = new List<int>();
            var colList = new List<int>();
            for(var i = 0; i < row; i++)
            {
                for(var j = 0; j < col; j++)
                {
                    if(matrix[i][j] == 0)
                    {
                        rowList.Add(i);
                        colList.Add(j);
                    }
                }
            }
            rowList = rowList.Distinct().ToList();
            colList = colList.Distinct().ToList();
            for (var i = 0; i < row; i++)
            {
                if (rowList.Contains(i))
                {
                    for(var j = 0; j < col; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }                
            }

            for (var i = 0; i < col; i++)
            {
                if (colList.Contains(i))
                {
                    for (var j = 0; j < row; j++)
                    {
                        matrix[j][i] = 0;
                    }
                }
            }
        }
    }
}
