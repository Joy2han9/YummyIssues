using System;
using System.Collections.Generic;
using System.Linq;

namespace issue15
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = ThreeSumBest(new int[] { -1, 0, 1, 2, -1, -4 });
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static IList<IList<int>> ThreeSumBest(int[] nums)
        {
            var result = new List<IList<int>>();
            int[] num = nums.OrderBy(x => x).ToArray();
            int start, end, temp;

            for (int i = 0; i < num.Length; i++)
            {
                if (i != 0 && num[i] == num[i - 1]) continue;

                int current = num[i];
                start = i + 1;
                end = num.Length - 1;
                while (start < end)
                {

                    if (start != i + 1 && num[start] == num[start - 1])
                    {
                        start++;
                        continue;
                    }

                    temp = num[start] + num[end];

                    if (temp == -current)
                    {

                        List<int> list = new List<int>(3);

                        list.Add(current);

                        list.Add(num[start]);

                        list.Add(num[end]);

                        result.Add(list);

                        start++; end--;

                    }
                    else if (temp > -current)
                    {
                        end--;
                    }

                    else
                    {
                        start++;
                    }
                }

            }

            return result;
        }
    }
}
