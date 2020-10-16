using System;
using System.Collections.Generic;
using System.Linq;

namespace issue42
{
    class Program
    {
        /// <summary>
        /// 给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var result = Trap(new int[] { 9, 8, 9, 5, 8, 8, 8, 0, 4});
            Console.WriteLine(result);
        }

        public static int Trap(int[] height)
        {
            if (height.Length < 3)
            {
                return 0;
            }
            var result = 0;
            var listResult = GetUsefulList(height);
            result = GetSumFromList(listResult);
            return result;
        }

        public static int GetSumFromList(List<List<int>> lists)
        {
            var sum = 0;
            foreach(var list in lists)
            {
                var min = Math.Min(list[0], list[list.Count - 1]);
                sum += list.Where(x => x < min).Sum(x => min - x);
            }
            return sum;
        }

        public static List<List<int>> GetUsefulList(int [] height)
        {
            var result = new List<List<int>>();
            var start = 0;
            var stop = 0;
            var maxStop = 0;
            var maxStopIndex = 0;
            var startSet = false;
            var stopSet = false;
            while(start <height.Length-2 && stop <height.Length)
            {
                if (!startSet)
                {
                    if (start == 0)
                    {
                        if (start == 0)
                        {
                            if (height[start] > height[start + 1])
                            {
                                stop = start + 2;
                                startSet = true;
                            }
                            else
                            {
                                start++;
                                continue;
                            }

                        }
                    }
                    else
                    {
                        if (height[start] >= height[start - 1] && height[start] >= height[start + 1])
                        {
                            if (start >= height.Length - 1)
                            {
                                break;
                            }
                            else
                            {
                                stop = start + 2;
                                startSet = true;
                            }
                        }
                        else
                        {
                            start++;
                            continue;
                        }
                    }
                }
                if (!stopSet)
                {
                    while (stop < height.Length)
                    {
                        if(height[stop]> maxStop && height[stop] > height[stop-1])
                        {
                            maxStop = height[stop];
                            maxStopIndex = stop;
                            stopSet = true;
                            if (maxStop >= height[start])
                            {
                                break;
                            }
                        }
                        stop++;
                    }
                    stop = maxStopIndex;
                }

                if(startSet && stopSet)
                {
                    var list = new List<int>();
                    while (start <= stop)
                    {
                        list.Add(height[start]);
                        start++;
                    }
                    result.Add(list);
                    startSet = false;
                    stopSet = false;
                    start = stop;
                    maxStop = 0;                    
                    stop+=2;                    
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
