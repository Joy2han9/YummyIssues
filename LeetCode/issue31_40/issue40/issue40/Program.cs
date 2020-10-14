using System;
using System.Collections.Generic;
using System.Linq;

namespace issue40
{
    /*
     * 给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。

        candidates 中的每个数字在每个组合中只能使用一次。

        说明：

        所有数字（包括目标数）都是正整数。
        解集不能包含重复的组合。 
        示例 1:

        输入: candidates = [10,1,2,7,6,1,5], target = 8,
        所求解集为:
        [
          [1, 7],
          [1, 2, 5],
          [2, 6],
          [1, 1, 6]
        ]
        示例 2:

        输入: candidates = [2,5,2,1,2], target = 5,
        所求解集为:
        [
          [1,2,2],
          [5]
        ]
     */
    class Program
    {
        static void Main(string[] args)
        {
            var result = CombinationSum2(new int[] { 4, 4, 2, 1, 4, 2, 2, 1, 3}, 6);
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var useful = candidates.Where(x => x <= target).OrderBy(x=>x).ToList();
            FindP(new List<int>(), useful);
            return result;

            void FindP(List<int> path, List<int> choose)
            {
                if (path.Sum().Equals(target))
                {
                    if (!result.Any())
                    {
                        result.Add(path);
                    }
                    else if (!Contain(result, path))
                    {
                        result.Add(path);
                    }
                }
                else if (path.Sum() < target)
                {                    
                    for (; choose.Any();)
                    {
                        var last = choose.Last();
                        choose.RemoveAt(choose.Count - 1);
                        FindP(new List<int>(path) { last }, new List<int>(choose));
                    }

                }
            }
        }

        public static bool Contain(List<IList<int>> originals, IList<int> me)
        {
            return originals.Any(x => Equal(x, me));
        }

        public static bool Equal(IList<int>you,IList<int>me)
        {
            if (you.Count != me.Count) return false;

            for(var i = 0; i < you.Count; i++)
            {
                if (you[i] != me[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
