using System;
using System.Collections.Generic;
using System.Linq;

namespace issue39
{
    class Program
    {
        /*
         给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。

            candidates 中的数字可以无限制重复被选取。

            说明：

            所有数字（包括 target）都是正整数。
            解集不能包含重复的组合。 
            示例 1：

            输入：candidates = [2,3,6,7], target = 7,
            所求解集为：
            [
              [7],
              [2,2,3]
            ]
            示例 2：

            输入：candidates = [2,3,5], target = 8,
            所求解集为：
            [
              [2,2,2,2],
              [2,3,3],
              [3,5]
            ]
 

            提示：

            1 <= candidates.length <= 30
            1 <= candidates[i] <= 200
            candidate 中的每个元素都是独一无二的。
            1 <= target <= 500
         */
        static void Main(string[] args)
        {
            var result = CombinationSum2(new int[] { 2,3,7 }, 18);
        }

        public static IList<IList<int>> CombinationSum1(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var useful = candidates.Where(x => x <= target).ToList();
            FindP(new List<int>(), useful);
            return result;

            void FindP(List<int> path, List<int> choose)
            {
                if (path.Sum().Equals(target))
                {
                    result.Add(path);
                }
                else if (path.Sum() < target)
                {
                    for (; choose.Any(); choose.RemoveAt(choose.Count - 1))
                    {
                        FindP(new List<int>(path) { choose.Last() }, new List<int>(choose));
                    }

                }

            }
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var res = new List<IList<int>>();
            var now = candidates.Where(x => x <= target).OrderBy(x => x).ToArray();
            FindP(new List<int>(), now.Length - 1, 0);
            return res;

            void FindP(List<int> path, int end, int sum)
            {
                if (sum.Equals(target))
                {
                    res.Add(path);
                }
                else if (sum < target)
                {
                    int need = target - sum;
                    while (end >= 0 && now[end] > need)
                    {
                        end--;
                    }
                    for (; end >= 0; end--)
                    {
                        FindP(new List<int>(path) { now[end] }, end, sum + now[end]);
                    }
                }
            }
        }

        public static IList<IList<int>> CombinationSum3(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            var temp = GetAllCombination(candidates, target);
            result.AddRange(temp);


            return result;
        }

        public static List<List<int>> GetAllCombination(int[] candidates, int current)
        {
            var result = new List<List<int>>();
            for (var i = 0; i < candidates.Length; i++)
            {
                var tempCurrent = current;
                var resTemp = new List<int>();
                for (var j = 0; j < candidates.Length;j++)
                {

                    resTemp = new List<int>();
                    tempCurrent = current;
                    while (tempCurrent > 0 && j < candidates.Length)
                    {
                        if (tempCurrent == candidates[j])
                        {
                            resTemp.Add(candidates[j]);
                            resTemp.Sort();
                            if (!Contain(result, resTemp))
                            {
                                result.Add(resTemp);
                            }                            
                            break;
                        }
                        else
                        {
                            resTemp.Add(candidates[i]);
                            tempCurrent -= candidates[i];
                        }
                    }
                }
            }

            return result;
        }

        public static bool Contain(List<List<int>> originals, List<int> my)
        {
            originals = originals.Where(x => x.Count == my.Count).ToList();

            return originals.Any(x => Equal(x,my));
        }

        public static bool Equal(List<int> me,List<int> you)
        {
            for(var i = 0; i < me.Count; i++)
            {
                if (me[i] != you[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
