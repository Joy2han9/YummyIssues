using System;
using System.Collections.Generic;

namespace issue72
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MinDistance("intentiondegas", "execution");
            Console.WriteLine(result);
        }

        public static int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;

            int[,] cost = new int[m + 1,n+1] ;

            for (int i = 0; i <= m; ++i)
            {
                cost[i,0] = i;
            }
            for (int j = 0; j <= n; ++j)
            {
                cost[0,j] = j;
            }
            for (int i = 1; i <= m; ++i)
            {
                for (int j = 1; j <= n; ++j)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        cost[i,j] = cost[i - 1,j - 1];
                    }
                    else
                    {
                        cost[i,j] = 1 + Math.Min(cost[i - 1,j - 1], Math.Min(cost[i,j - 1], cost[i - 1,j]));
                    }
                }
            }
            return cost[m,n];
        }
    }
}
