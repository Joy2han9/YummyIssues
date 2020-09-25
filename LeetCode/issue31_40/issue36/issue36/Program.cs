using System;
using System.Collections.Generic;
using System.Linq;

namespace issue36
{
    class Program
    {
        static void Main(string[] args)
        {
            var myArray = new char[9][]
            {
                new char [] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                new char [] { '6', '.', '.', '1', '9', '5', '.', '.', '.'},
                new char [] { '.', '9', '8', '.', '.', '.', '.', '6', '.'},
                new char [] {'8', '.', '.', '.', '6', '.', '.', '.', '3'},
                new char [] {'4', '.', '.', '8', '.', '3', '.', '.', '1'},
                new char [] {'7', '.', '.', '.', '2', '.', '.', '.', '6'},
                new char [] {'.', '6', '.', '.', '.', '.', '2', '8', '.'},
                new char [] {'.', '.', '.', '4', '1', '9', '.', '.', '5'},
                new char [] {'.', '.', '.', '.', '8', '.', '.', '7', '9'}
            };

            var result = IsValidSudoku(myArray);
            Console.WriteLine(result);
        }

        public static bool IsValidSudoku(char[][] board)
        {
            var listRow = new List<char>();
            var listCow = new List<char>();
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    listRow.Add(board[i][j]);
                    listCow.Add(board[j][i]);
                }

                if(!IsValid(listRow) || !IsValid(listCow))
                {
                    return false;
                }
                listRow.Clear();
                listCow.Clear();
            }
            listRow.Clear();
            for (var i = 0; i < 3; i++)
            {
                for(var j = 0; j < 3; j++)
                {
                    AddToList(listRow, board, i*3, j*3);
                    if (!IsValid(listRow))
                    {
                        return false;
                    }
                    listRow.Clear();
                }
            }

            return true;
        }

        public static bool IsValid(List<char> myList)
        {
            var group = myList.Where(x=>x != '.').GroupBy(x => x);

            return !group.Any(x => x.Count() > 1);
        }

        public static void AddToList(List<char> myList, char[][] board,int row,int cow)
        {
            for(var i = 0; i < 3; i++)
            {
                for(var j = 0; j < 3; j++)
                {
                    myList.Add(board[row + i][cow + j]);
                }
            }
        }
    }
}
