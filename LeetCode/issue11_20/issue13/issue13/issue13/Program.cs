using System;
using System.Collections.Generic;

namespace issue13
{
    class Program
    {
        /*
         * 罗马数字包含以下七种字符: I， V， X， L，C，D 和 M。

            字符          数值
            I             1
            V             5
            X             10
            L             50
            C             100
            D             500
            M             1000
            例如， 罗马数字 2 写做 II ，即为两个并列的 1。12 写做 XII ，即为 X + II 。 27 写做  XXVII, 即为 XX + V + II 。

            通常情况下，罗马数字中小的数字在大的数字的右边。但也存在特例，例如 4 不写做 IIII，而是 IV。数字 1 在数字 5 的左边，所表示的数等于大数 5 减小数 1 得到的数值 4 。同样地，数字 9 表示为 IX。这个特殊的规则只适用于以下六种情况：

            I 可以放在 V (5) 和 X (10) 的左边，来表示 4 和 9。
            X 可以放在 L (50) 和 C (100) 的左边，来表示 40 和 90。 
            C 可以放在 D (500) 和 M (1000) 的左边，来表示 400 和 900。
            给定一个罗马数字，将其转换成整数。输入确保在 1 到 3999 的范围内。
         */
        static void Main(string[] args)
        {
            var result = RomanToInt("IV");
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static int RomanToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            var dic = GetDic();

            var tempStr = s;
            var temp = "";
            var result = 0;
            while (tempStr.Length > 0)
            {
                if (tempStr.Length >= 2)
                {
                    temp = tempStr[0].ToString() + tempStr[1].ToString();
                    if (dic.ContainsKey(temp))
                    {
                        result += dic[temp];
                        tempStr = tempStr.Substring(2);
                    }
                    else
                    {
                        temp = tempStr[0].ToString();
                        result += dic[temp];
                        tempStr = tempStr.Substring(1);
                    }
                }
                else
                {
                    result += dic[tempStr];
                    tempStr = "";
                }
            }

            return result;
        }

        private static Dictionary<string, int> GetDic()
        {
            Dictionary<string, int> myDic = new Dictionary<string, int>();
            myDic.Add("I", 1);
            myDic.Add("V", 5);
            myDic.Add("X", 10);
            myDic.Add("L", 50);
            myDic.Add("C", 100);
            myDic.Add("D", 500);
            myDic.Add("M", 1000);

            myDic.Add("IV", 4);
            myDic.Add("IX", 9);
            myDic.Add("XL", 40);
            myDic.Add("XC", 90);

            myDic.Add("CD", 400);
            myDic.Add("CM", 900);

            return myDic;
        }
    }
}
