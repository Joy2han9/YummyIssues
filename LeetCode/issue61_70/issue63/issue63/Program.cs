using System;

namespace issue63
{
    class Program
    {
        static int[,] myArray = new int[101, 101];
        static void Main(string[] args)
        {
            var obstacleGrid = new int[][] {
                new int []{0,0,0,0},
                new int []{0,1,0,0},
                new int []{0,0,1,0},
                new int []{0,0,0,0},
            };

            var result = UniquePathsWithObstacles(obstacleGrid);
            Console.WriteLine(result);
        }

        /// <summary>
        /// new bee, I just can't understand it.
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public static int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            if (obstacleGrid[0][0] == 1) return 0;
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            int[] dp = new int[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1) { dp[j] = 0; }
                    else if (i == 0)
                    {
                        dp[j] = j - 1 < 0 ? 1 : Math.Min(dp[j - 1], 1);
                    }
                    else
                    {
                        dp[j] = dp[j] + (j - 1 < 0 ? 0 : dp[j - 1]);
                    }

                }
            }

            return dp[n - 1];
        }

        /// <summary>
        /// can only process 1 obstacle.
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public static int UniquePathsWithObstacles1(int[][] obstacleGrid)
        {
            if (myArray[1, 1] == 0)
            {
                init();
            }
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;

            var resultAll = myArray[m, n];
            var obstacleM = 0;
            var obstacleN = 0;
            for(var i = 0; i < m; i++)
            {
                for(var j = 0; j < n; j++)
                {
                    if(obstacleGrid[i][j] == 1)
                    {
                        obstacleM = i;
                        obstacleN = j;

                        var resultStart = myArray[m - obstacleM, n - obstacleN];
                        var resultEnd = myArray[obstacleM + 1, obstacleN + 1];
                        resultAll -= resultStart * resultEnd;
                    }
                }
            }
            
            return resultAll;
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
                    myArray[i, j] = myArray[i - 1, j] + myArray[i, j - 1];
                }
            }
        }
    }
}
