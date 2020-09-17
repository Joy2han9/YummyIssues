using System;
using System.Collections.Generic;
using System.Linq;

namespace issue30
{
    /*
     * 给定一个字符串 s 和一些长度相同的单词 words。找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。

        注意子串要与 words 中的单词完全匹配，中间不能有其他字符，但不需要考虑 words 中单词串联的顺序。

 

        示例 1：

        输入：
          s = "barfoothefoobarman",
          words = ["foo","bar"]
        输出：[0,9]
        解释：
        从索引 0 和 9 开始的子串分别是 "barfoo" 和 "foobar" 。
        输出的顺序不重要, [9,0] 也是有效答案。
        示例 2：

        输入：
          s = "wordgoodgoodgoodbestword",
          words = ["word","good","best","word"]
        输出：[]
     */
    class Program
    {
        static void Main(string[] args)
        {
            var result = FindSubstring("abababab"
, new string[] { "a", "b", "a" });
            Console.ReadKey();
        }

        public static IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            var wordLength = words[0].Length;
            var wholeLength = words.Length * wordLength;
            var index = -1;
            var currentPosition = 0;

            var distinctWrods = words.Distinct().ToList();
            if(distinctWrods.Count==2 & distinctWrods.Count < words.Length && wordLength >1)
            {
                var temp1 = Convert.ToString(distinctWrods[0][0]) + Convert.ToString(distinctWrods[1][wordLength - 1]);
                var temp2 = Convert.ToString(distinctWrods[0][1]) + Convert.ToString(distinctWrods[1][0]);
                if(s.IndexOf(temp1)==-1&& s.IndexOf(temp2) == -1)
                {
                    return result;
                }
            }
            

            while (s.Length >= wholeLength)
            {
                index = FindIndex(s, words.ToList());
                if (index != -1)
                {
                    currentPosition += index;
                    result.Add(currentPosition);
                    currentPosition += 1;
                    s = s.Substring(index + 1);
                }
                else
                {
                    s = s.Substring(1);
                    currentPosition += 1;
                }
            }
            
            return result;
        }

        public static int FindIndex(string s,List<string> words)
        {
            var index = s.Length;
            var wordLenght = words.First().Length;
            for(var i = 0; i < words.Count; i++)
            {
                var current = s.IndexOf(words[i]);
                index = Math.Min(index, current);
                if (index == 0) break;
                if (index == -1) return -1;
            }            

            s = s.Substring(index);
            words.Remove(words.First(x => x == s.Substring(0, wordLenght)));
            s = s.Substring(wordLenght);
            while (words.Any() && s.Length>= wordLenght)
            {
                if(words.Any(x=>x == s.Substring(0, wordLenght)))
                {
                    words.Remove(words.First(x => x == s.Substring(0, wordLenght)));
                    s = s.Substring(wordLenght);
                }
                else
                {
                    break;
                }
            }
            if (words.Any())
            {
                return -1;
            }
            else
            {
                return index;
            }
        }
    }
}
