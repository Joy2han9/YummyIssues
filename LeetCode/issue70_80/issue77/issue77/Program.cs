using System;
using System.Collections.Generic;

namespace issue77
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 4;
            var k = 2;
            var result = Combine(n, k);
            Console.ReadKey();
        }

        public static IList<IList<int>> Combine(int n, int k)
        {
            var myList = new List<int>();
            for(var i = 1; i <= n; i++)
            {
                myList.Add(i);
            }
            var result = GetCombination(myList, k);

            return result;
        }

        public static List<IList<int>> GetCombination(List<int> t, int n)
        {
            if (t.Count < n)
            {
                return null;
            }
            int[] temp = new int[n];
            List<IList<int>> list = new List<IList<int>>();
            GetCombination(ref list, t, t.Count, n, temp, n);
            return list;
        }

        public static void GetCombination(ref List<IList<int>> result, List<int> list, int n, int m, int[] b, int M)
        {
            for (int i = n; i >= m; i--)
            {
                b[m - 1] = i;
                if (m > 1)
                {
                    GetCombination(ref result, list, i - 1, m - 1, b, M);
                }
                else
                {
                    if (result == null)
                    {
                        result = new List<IList<int>>();
                    }
                    List<int> temp = new List<int>();
                    temp.AddRange(b);
                    result.Add(temp);
                }
            }
        }
    }
}
