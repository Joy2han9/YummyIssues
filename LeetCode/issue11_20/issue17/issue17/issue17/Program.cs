using System;
using System.Collections.Generic;

namespace issue17
{
    class Program
    {
        //给定一个仅包含数字 2-9 的字符串，返回所有它能表示的字母组合。
        //手机九键输入法对应关系。

        static void Main(string[] args)
        {
            var input = "23";
            var results = LetterCombinations(input);

            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
            Console.ReadKey();
        }

        public static List<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(digits))
            {
                return result;
            }
            var strLength = digits.Length;

            var lettersList = new List<List<string>>();
            for(var i = 0; i < strLength; i++)
            {
                var letterList = GetLettersWithNumber(digits[i]);
                lettersList.Add(letterList);
            }

            Descartes(lettersList, 0, result, string.Empty);

            return result;
        }

        private static void Descartes(List<List<string>> list, int count, List<string> result, string data)
         {
             
              List<string> curr = list[count];
              foreach(var item in curr)
              {
                   if(count+1< list.Count)
                  {
                      Descartes(list, count+1, result, data+item);
                  }
                  else
                  {
                      result.Add(data+item);
                  }
              }
              
         }

        public static List<string> GetLettersWithNumber(char myStr)
        {
            var dics = new Dictionary<char, List<string>>();
            dics.Add('2', new List<string>{ "a","b","c"});
            dics.Add('3', new List<string> { "d", "e", "f" });
            dics.Add('4', new List<string> { "g", "h", "i" });
            dics.Add('5', new List<string> { "j", "k", "l" });
            dics.Add('6', new List<string> { "m", "n", "o" });
            dics.Add('7', new List<string> { "p", "q", "r","s" });
            dics.Add('8', new List<string> { "t", "u", "v" });
            dics.Add('9', new List<string> { "w", "x", "y","z" });

            return dics.GetValueOrDefault(myStr);
        }
    }
}
