using System;

namespace issue8
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = MyAtoi("-6543210");

            Console.WriteLine(result);
            Console.ReadKey();
        }

        private static string validStr = "+-0123456789";
        private static string validNum = "0123456789";
        public static int MyAtoi(string str)
        {
            string tempStr = str.TrimStart();
            if (tempStr.Length == 0 || !validStr.Contains(tempStr[0]))
            {
                return 0;
            }

            var result = 0;
            int.TryParse(tempStr, out result);
            if (result != 0)
            {
                return result;
            }

            var resultStr = new System.Text.StringBuilder();
            resultStr.Append(tempStr[0]);

            for (var i = 1; i < tempStr.Length; i++)
            {
                var current = tempStr[i];

                if (!validNum.Contains(current))
                {
                    break;
                }
                else
                {
                    resultStr.Append(current);
                }

            }
            double doubleresult = 0;

            double.TryParse(resultStr.ToString(), out doubleresult);
            
            if (doubleresult >= 0 && doubleresult >= int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (doubleresult >= 0 && doubleresult < int.MaxValue)
            {
                return int.Parse(doubleresult.ToString());
            }

            if (doubleresult < 0 && doubleresult < int.MinValue)
            {
                return int.MinValue;
            }
            if (doubleresult < 0 && doubleresult > int.MinValue)
            {
                return int.Parse(doubleresult.ToString());
            }

            return result;
        }
    }
}
