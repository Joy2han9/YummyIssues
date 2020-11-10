using System;
using System.Linq;

namespace issue57
{
    class Program
    {
        /*
         * 给出一个无重叠的 ，按照区间起始端点排序的区间列表。

            在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。

 

            示例 1：

            输入：intervals = [[1,3],[6,9]], newInterval = [2,5]
            输出：[[1,5],[6,9]]
            示例 2：

            输入：intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
            输出：[[1,2],[3,10],[12,16]]
            解释：这是因为新的区间 [4,8] 与 [3,5],[6,7],[8,10] 重叠。
 

            注意：输入类型已在 2019 年 4 月 15 日更改。请重置为默认代码定义以获取新的方法签名。
         */
        static void Main(string[] args)
        {
            var myArray = new int[][]
            {
                new int []{1,3},
                new int []{6,9},
            };
            var newArray = new int[] { 2, 5 };

            var result = Insert(myArray, newArray);

        }

        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var result = intervals.ToList();
            result.Add(newInterval);
            result = result.OrderBy(x => x[0]).ThenBy(x => x[1]).ToList();

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
                    if (nextIndex == result.Count - 1)
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
