using System;

namespace issue11
{
    class Program
    {
        /*
         *给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。
         * 在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0)。
         * 找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水。

        说明：你不能倾斜容器，且 n 的值至少为 2。
        */
        static void Main(string[] args)
        {
            var myArray = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var result = MaxArea(myArray);
            Console.WriteLine(result);
            Console.ReadKey();
        }
        //从外侧双向往内侧移动，并计算最大area
        public static int MaxArea(int[] height)
        {
            int area = 0;
            int i = 0;
            int j = height.Length - 1;
            while (j != i)
            {
                if (height[i] <= height[j])
                {
                    area = area > (j - i) * height[i] ? area : (j - i) * height[i];
                    i++;
                }
                else
                {
                    area = area > (j - i) * height[j] ? area : (j - i) * height[j];
                    j--;
                }

            }
            return area;
        }
    }
}
