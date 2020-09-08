using System;
namespace issue6
{
    class Program
    {
        /*
            L   C   I   R
            E T O E S I I G
            E   D   H   N
            之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："LCIRETOESIIGEDHN"。

            请你实现这个将字符串进行指定行数变换的函数：

            string convert(string s, int numRows);
            示例 1:

            输入: s = "LEETCODEISHIRING", numRows = 3
            输出: "LCIRETOESIIGEDHN"
            示例 2:

            输入: s = "LEETCODEISHIRING", numRows = 4
            输出: "LDREOEIIECIHNTSG"
            解释:

            L     D     R
            E   O E   I I
            E C   I H   N
            T     S     G
        */
        static void Main(string[] args)
        {
            var result = Convert("LEETCODEISHIRING", 3);

            Console.WriteLine(result);
            Console.ReadKey();
        }

        //第一步获取二维数组
        //第二步填写值
        //第三步获取数组的字符串
        public static string Convert(string s, int numRows)
        {
            if (numRows < 2)
            {
                return s;
            }

            var result = string.Empty;
            var width = numRows - 1;
            var single = width * 2;

            var step = s.Length / single;
            if (s.Length % single != 0)
            {
                step++;
            }

            var myArray = new string[step * width, numRows];
            var index = 0;
            for (var i = 0; i < step * width; i++)
            {
                for (var j = 0; j < numRows; j++)
                {
                    if (index < s.Length)
                    {
                        if (i % width == 0)
                        {
                            myArray[i, j] = System.Convert.ToString(s[index]);
                            index++;
                        }
                        else if ((i + j) % width == 0)
                        {
                            myArray[i, j] = System.Convert.ToString(s[index]);
                            index++;
                        }
                    }
                }
            }

            var strBuffer = new System.Text.StringBuilder();

            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; j < step * width; j++)
                {
                    strBuffer.Append(myArray[j, i]);
                }
            }
            result = strBuffer.ToString();
            return result;
        }
    }
}
