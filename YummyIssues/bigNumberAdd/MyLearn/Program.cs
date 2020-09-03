using System;
using System.Collections.Generic;

namespace MyLearn
{
    class Program
    {
        //大数相加
        static void Main(string[] args)
        {            
            var result = GetBigAmountSum("456789451654567984561564567897145615649857984156165498789456156498789415615648978465",
                "156489798789456165156465498798764561235645689798465465789");

            Console.WriteLine(result);
        }

        public static string GetBigAmountSum(string strA, string strB)
        {
            var result = string.Empty;
            var bigAmountsA = GetBigAmountFromString(strA);
            var bigAmountsB = GetBigAmountFromString(strB);
            var bigAmountsResult = GetAddResult(bigAmountsA, bigAmountsB);
            result = GetStringFromBigAmounts(bigAmountsResult);
            return result;
        }

        public static string GetStringFromBigAmounts(List<BigAmount> bigAmounts)
        {
            var result = string.Empty;
            bool isAddOne = false;
            for(var i = 0; i < bigAmounts.Count; i++)
            {
                var bigAmount = bigAmounts[i];
                var intValue = GetIntValueFromString(bigAmount.Value);
                if (isAddOne)
                {
                    intValue++;
                }
                isAddOne = bigAmount.IsAddOne;
                result = intValue.ToString() + result;

            }
            return result;
        }

        public static List<BigAmount> GetAddResult(List<BigAmount> bigAmountsA, List<BigAmount> bigAmountsB)
        {
            var bigAmounts = new List<BigAmount>();
            var largeCount = bigAmountsA.Count > bigAmountsB.Count ? bigAmountsA.Count : bigAmountsB.Count;
            for(var i = 0; i < largeCount; i++)
            {
                var bigA = bigAmountsA.Count > i ? bigAmountsA[i] : new BigAmount() { Value = "" };
                var bigB = bigAmountsB.Count > i ? bigAmountsB[i] : new BigAmount() { Value = "" };
                var bigAmount = Add(bigA, bigB);
                bigAmounts.Add(bigAmount);
            }
            
            return bigAmounts;
        }

        public static BigAmount Add(BigAmount bigA,BigAmount bigB)
        {
            var bigResult = new BigAmount();
            var addResult = GetIntValueFromString(bigA.Value) + GetIntValueFromString(bigB.Value);
            if(addResult > 1000000000)
            {
                addResult -= 1000000000;
                bigResult.IsAddOne = true;
            }

            bigResult.Value = addResult.ToString();
            bigResult.level = string.IsNullOrEmpty(bigA.Value) ? bigB.level : bigA.level;
            return bigResult;
        }

        public static int GetIntValueFromString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }

            return int.Parse(str);
        }

        public class BigAmount
        {
            public string Value { get; set; }
            public int level { get; set; }
            public bool IsAddOne { get; set; }
        }

        public static List<BigAmount> GetBigAmountFromString(string input)
        {
            var bigAmounts = new List<BigAmount>();
            var size = 9;
            int level = 1;
            var strLength = input.Length - 1;
            var done = false;
            for(var i = strLength; i >= 0; i--)
            {
                if (done)
                {
                    break;
                }
                var bigAmount = new BigAmount()
                {
                    level = level,
                };
                for (var j = 0; j < size; j++)
                {
                    var currentIndex = strLength - (level - 1) * size - j;
                    if (currentIndex < 0)
                    {
                        done = true;
                        break;
                    }
                    bigAmount.Value = input[currentIndex] + bigAmount.Value;
                    
                    
                }
                level++;
                bigAmounts.Add(bigAmount);
            }

            return bigAmounts;
        }
    }
}
