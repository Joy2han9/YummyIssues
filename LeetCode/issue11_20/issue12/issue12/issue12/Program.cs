using System;
using System.Collections.Generic;
using System.Linq;

namespace issue12
{
    class Program
    {
        /*
         罗马数字包含以下七种字符： I， V， X， L，C，D 和 M。

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
            给定一个整数，将其转为罗马数字。输入确保在 1 到 3999 的范围内。

            示例 1:

            输入: 3
            输出: "III"
            示例 2:

            输入: 4
            输出: "IV"
            示例 3:

            输入: 9
            输出: "IX"
            示例 4:

            输入: 58
            输出: "LVIII"
            解释: L = 50, V = 5, III = 3.
            示例 5:

            输入: 1994
            输出: "MCMXCIV"
            解释: M = 1000, CM = 900, XC = 90, IV = 4.
         */
        static void Main(string[] args)
        {
            var result = IntToRoman(3999);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        public static string IntToRoman(int num)
        {
            var dic = GetDic();
            if (dic.Keys.Contains(num))
            {
                return dic[num];
            }

            var result = "";
            var current = 0;
            var numStr = num.ToString();

            while (numStr.Length > 0)
            {
                if (numStr[0] == '0')
                {
                    numStr = numStr.Substring(1);
                    continue;
                }
                if (numStr.Length == 4)
                {
                    current = int.Parse(numStr[0] + "000");
                    result += dic[current];
                }

                if (numStr.Length == 3)
                {
                    current = int.Parse(numStr[0] + "00");
                    result += dic[current];
                }

                if (numStr.Length == 2)
                {
                    current = int.Parse(numStr[0] + "0");
                    result += dic[current];
                }

                if (numStr.Length == 1)
                {
                    result += dic[int.Parse(numStr)];
                }
                numStr = numStr.Substring(1);
            }
            return result;
        }

        private static Dictionary<int, string> GetDic()
        {
            Dictionary<int, string> myDic = new Dictionary<int, string>();
            myDic.Add(1, "I");
            myDic.Add(2, "II");
            myDic.Add(3, "III");
            myDic.Add(4, "IV");
            myDic.Add(5, "V");
            myDic.Add(6, "VI");
            myDic.Add(7, "VII");
            myDic.Add(8, "VIII");
            myDic.Add(9, "IX");
            myDic.Add(10, "X");


            myDic.Add(20, "XX");
            myDic.Add(30, "XXX");
            myDic.Add(40, "XL");
            myDic.Add(50, "L");
            myDic.Add(60, "LX");
            myDic.Add(70, "LXX");
            myDic.Add(80, "LXXX");
            myDic.Add(90, "XC");
            myDic.Add(100, "C");

            myDic.Add(200, "CC");
            myDic.Add(300, "CCC");
            myDic.Add(400, "CD");
            myDic.Add(500, "D");
            myDic.Add(600, "DC");
            myDic.Add(700, "DCC");
            myDic.Add(800, "DCCC");
            myDic.Add(900, "CM");
            myDic.Add(1000, "M");

            myDic.Add(2000, "MM");
            myDic.Add(3000, "MMM");
            return myDic;
        }
    }
}