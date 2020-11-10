using System;
using System.Linq;

namespace issue56
{
    class Program
    {
        /*
         * 给出一个区间的集合，请合并所有重叠的区间。
            示例 1:

            输入: intervals = [[1,3],[2,6],[8,10],[15,18]]
            输出: [[1,6],[8,10],[15,18]]
            解释: 区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].
            示例 2:

            输入: intervals = [[1,4],[4,5]]
            输出: [[1,5]]
            解释: 区间 [1,4] 和 [4,5] 可被视为重叠区间。
            注意：输入类型已于2019年4月15日更改。 请重置默认代码定义以获取新方法签名。

 

            提示：

            intervals[i][0] <= intervals[i][1]
         */
        static void Main(string[] args)
        {
            var myArray = new int[][] { new int[] {2,3 }, new int[] { 2, 2 }, new int[] { 3, 3 }, new int[] {1,3 }, new int[] { 5, 7 }, new int[] { 2, 2 }, new int[] { 4, 6 }, };            
            var result = Merge(myArray);

        }

        public static int[][] Merge(int[][] intervals)
        {
            if(intervals.Length == 1)
            {
                return intervals;
            }

            var result = intervals.OrderBy(x=>x[0]).ThenBy(x=>x[1]).ToList();
            var currentIndex = 0;
            var nextIndex = 1;
            while (currentIndex < result.Count && nextIndex < result.Count)
            {                
                var current = result[currentIndex];
                var next = result[nextIndex];
                if (current[1] >= next[0])
                {
                    if (current[1] < next[1])
                    {
                        current[1] = next[1];
                    }
                    result.RemoveAt(nextIndex);
                }
                else
                {
                    if (nextIndex == result.Count-1)
                    {
                        currentIndex++;
                        nextIndex = currentIndex;
                        nextIndex++;
                    }
                    else
                    {
                        nextIndex++;
                    }
                }

            }

            return result.ToArray();
        }
    }
}
