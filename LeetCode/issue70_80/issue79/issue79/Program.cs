using System;
using System.Collections.Generic;

namespace issue79
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new char[][] {
                new char []{ 'A', 'B', 'C', 'E'},
                new char []{ 'S', 'F', 'C', 'S' },
                new char []{ 'A', 'D', 'E', 'E'},
            };

            var word = "SEE";
            var start = DateTime.Now;
            var result = Exist(board, word);
            Console.WriteLine((DateTime.Now - start).TotalMilliseconds);
        }

        public static bool Exist(char[][] board, string word)
        {            
            var capacity = board[0].Length * board.Length;
            if (capacity < word.Length || !Check(board, word))
            {
                return false;
            }

            var result = false;
            var startPositions = new List<int[]>();
            for(var i = 0; i < board.Length; i++)
            {
                for(var j = 0; j < board[i].Length; j++)
                {
                    if(board[i][j] == word[0])
                    {
                        startPositions.Add(new int[] { i, j });
                    }
                }
            }
            var currentIndex = 0;
            if (startPositions.Count>0)
            {
                currentIndex++;
            }
            if(currentIndex == word.Length)
            {
                return true;
            }
            else
            {
                foreach (var startPos in startPositions)
                {
                    var usedPos = new List<string>() {
                        startPos[0].ToString() +startPos[1]
                    };
                    if (FindRoad(board, usedPos, startPos[0], startPos[1], word[currentIndex], currentIndex, word))
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
            }
            

            return result;
        }

        public static bool Check(char[][]board,string word)
        {
            var result = true;
            var dic = new Dictionary<char, int>();
            for(var i = 0; i < board.Length; i++)
            {
                for(var j = 0; j < board[0].Length; j++)
                {
                    if (!dic.ContainsKey(board[i][j]))
                    {
                        dic.Add(board[i][j], 1);
                    }
                    else
                    {
                        dic[board[i][j]]++;
                    }
                }
            }

            foreach(var letter in word)
            {
                if (dic.ContainsKey(letter))
                {
                    dic[letter]--;
                    if (dic[letter] < 0)
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static bool FindRoad(char [][]board,List<string> usedPos,int x,int y,char currentChar,int currentIndex,string word)
        {
            var availablePoses = GetAvailablePos(board, usedPos, x, y, currentChar);
            if (availablePoses.Count > 0)
            {
                if(++currentIndex == word.Length)
                {
                    return true;
                }
                currentChar = word[currentIndex];

                foreach (var availablePos in availablePoses)
                {
                    usedPos.Add(availablePos[0].ToString() + availablePos[1]);
                    if(FindRoad(board, usedPos, availablePos[0], availablePos[1], currentChar, currentIndex, word))
                    {
                        return true;
                    }
                    else
                    {
                        usedPos.RemoveAt(usedPos.Count - 1);
                        continue;
                    }                   
                }
            }

            return false;
        }

        public static List<int[]> GetAvailablePos(char[][] board, List<string> usedPos, int x, int y, char currentChar)
        {
            var result = new List<int[]>();
            //left
            if (y > 0 && board[x][y - 1] == currentChar && !usedPos.Contains((x).ToString()+(y-1).ToString()))
            {
                result.Add(new int[] { x, y - 1 });
            }

            //up
            if (x>0 && board[x-1][y] == currentChar && !usedPos.Contains((x-1).ToString()+y))
            {
                result.Add(new int[] { x - 1, y });
            }

            //right
            if (y+1 < board[0].Length && board[x][y + 1] == currentChar && !usedPos.Contains(x.ToString()+(y + 1 )))
            {
                result.Add(new int[] { x, y + 1 });
            }

            //down
            if (x+1 < board.Length && board[x + 1][y] == currentChar && !usedPos.Contains((x + 1).ToString()+y ))
            {
                result.Add(new int[] { x + 1, y });
            }

            return result;
        }
    }
}
