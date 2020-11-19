using System;

namespace issue64
{
    class Program
    {
        /*
         * 给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。

            说明：每次只能向下或者向右移动一步。

 

            示例 1：


            输入：grid = [[1,3,1],[1,5,1],[4,2,1]]
            输出：7
            解释：因为路径 1→3→1→1→1 的总和最小。
            示例 2：

            输入：grid = [[1,2,3],[4,5,6]]
            输出：12
 

            提示：

            m == grid.length
            n == grid[i].length
            1 <= m, n <= 200
            0 <= grid[i][j] <= 100
         */
        static void Main(string[] args)
        {
            var grid = new int[][] { 
                new int []{1,3,1},
                new int []{1,5,1},
                new int []{4,2,1},
            };
            var result = MinPathSum(grid);
        }

        public static int MinPathSum(int[][] grid)
        {            
            var m = grid.Length;
            var n = grid[0].Length;

            int[,] dp = new int[m,n];
            for (var i = 0; i < m; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    var min = 0;
                    if (i == 0 && j !=0)
                    {
                        min = dp[i,j-1];
                    }
                    else if (i != 0 && j == 0)
                    {
                        min = dp[i-1,j];
                    }
                    else if(i!=0 && j!=0)
                    {
                        min = Math.Min(dp[i,j - 1], dp[i - 1,j]);
                    }
                    
                    dp[i,j] = grid[i][j] + min;
                }
            }

            return dp[m - 1,n - 1];
        }
    }
}
