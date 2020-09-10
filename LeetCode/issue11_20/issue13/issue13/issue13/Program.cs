using System;
using System.Collections.Generic;

namespace issue13
{
    class Program
    {
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
