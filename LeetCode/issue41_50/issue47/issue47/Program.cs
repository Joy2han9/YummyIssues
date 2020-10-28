using System;
using System.Collections.Generic;
using System.Text;

namespace issue47
{
    class Program
    {
        /*
         * 给定一个可包含重复数字的序列，返回所有不重复的全排列。

            示例:

            输入: [1,1,2]
            输出:
            [
              [1,1,2],
              [1,2,1],
              [2,1,1]
            ]
         */
        private bool[] vis;
        static void Main(string[] args)
        {
            var result = PermuteUnique(new int[] { 1, 1, 2 });
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var ans = new List<IList<int>>();
            var perm = new List<int>();
            vis = new bool[nums.Length];
            Array.Sort(nums);
            backtrack(nums, ans, perm);
            return ans;
        }

        public void backtrack(int[] nums, List<IList<int>> ans, List<int> perm)
        {
            if (perm.Count == nums.Length)
            {
                ans.Add(new List<int>(perm));
                return;
            }
            for (int i = 0; i < nums.Length; ++i)
            {
                if (vis[i] || (i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]))
                {
                    continue;
                }
                perm.Add(nums[i]);
                vis[i] = true;
                backtrack(nums, ans, perm);
                vis[i] = false;
                perm.RemoveAt(perm.Count - 1);
            }
        }

        public static IList<IList<int>> PermuteUnique1(int[] nums)
        {
            var result = new List<IList<int>>();
            var strResult = new List<string>();

            perm(nums, 0, nums.Length - 1);

            void perm(int[] list, int i, int n)
            {
                int j;

                if (i == n)
                {
                    var tempStr = GetStrValueFromIntArray(list);
                    if (!strResult.Contains(tempStr))
                    {
                        strResult.Add(tempStr);
                        result.Add(new List<int>(list));
                    }
                }
                else
                {
                    for (j = i; j <= n; j++)
                    {
                        if (i == j || list[i] == list[j])
                        {
                            perm(list, i + 1, n);
                        }
                        else
                        {
                            SWAP(ref list[i], ref list[j]);
                            perm(list, i + 1, n);
                            SWAP(ref list[i], ref list[j]);//数组一定要复原！！！！！                     
                        }                            
                    }
                }
            }
            void SWAP(ref int a, ref int b)
            {
                int c = a;
                a = b;
                b = c;
            }

            return result;
        }

        public static string GetStrValueFromIntArray(int[] array)
        {
            var stringBuilder = new StringBuilder();
            for(var i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
