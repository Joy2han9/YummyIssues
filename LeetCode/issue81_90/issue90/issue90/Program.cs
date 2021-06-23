using System;
using System.Collections.Generic;
using System.Linq;

namespace issue90
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1,2,2 };
            var result = SubsetsWithDup(arr);
            
        }

        public static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var result = new List<IList<int>>()
            {
                new List<int>(),
            };

            var list = new List<string>();
            foreach (int s in nums)
            {
                List<IList<int>> lst = result.GetRange(0, result.Count);
                List<int> nArr = new List<int>() { s };
                foreach (List<int> ss in lst)
                {
                    var temp = ss.Concat(nArr).OrderBy(x => x).ToList();
                    var tempStr = string.Join(',', temp);
                    if (list.Contains(string.Join(',',temp)))
                    {
                        continue;
                    }
                    else
                    {
                        list.Add(tempStr);
                        result.Add(temp);
                    }
                }
            }

            return result;
        }
    }
}
