using System;

namespace issue74
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[][] { 
                new int []{1},
            };

            SearchMatrix(matrix, 3);
        }

        public static bool SearchMatrix(int[][] matrix, int target)
        {
            var width = matrix.Length;
            var deepth = matrix[0].Length;
            var length = width * deepth;
          
            var myArray = new int[length];
            var index = 0;
            for(var i = 0; i < width; i++)
            {
                for(var j = 0; j < deepth; j++)
                {
                    myArray[index++] = matrix[i][j];
                }
            }

            var result = -1;
            result = BinarySearch(myArray, 0, length, target);
            return result > -1;
        }

        public static int BinarySearch(int[] arr, int low, int high, int key)
        {
            int mid = (low + high) / 2;
            if (mid >= arr.Length) return -1;
            if (low > high)
            {
                return -1;
            }                
            else
            {
                if (arr[mid] == key)
                    return mid;
                else if (arr[mid] > key)
                    return BinarySearch(arr, low, mid - 1, key);
                else
                    return BinarySearch(arr, mid + 1, high, key);
            }
        }
    }
}
