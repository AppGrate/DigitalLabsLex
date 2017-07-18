using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DigitalConverterLex.BusinessLayer.Strategy
{
    public static class DecimalNumber
    {
        public static string FindComplement(int complementType, string number, int numberBase)
        {
            string retResult = "";
            int decimalNumber = 0;
            int padding = number.Length;
            if (complementType == numberBase)
            {
                var len = number.ToString().Length;
                var dNo = ToBase10(numberBase, number);
                decimalNumber = (int)Math.Pow(numberBase, len) - dNo;
                retResult = FromBase10(numberBase, decimalNumber).PadLeft(padding, '0');
            }
            else if ((complementType + 1) == numberBase)
            {
                var len = number.ToString().Length;
                var dNo = ToBase10(numberBase, number);
                decimalNumber = (int)Math.Pow(numberBase, len) - 1 - dNo;
                retResult = FromBase10(numberBase, decimalNumber).PadLeft(padding, '0');
            }
            else
            {
                retResult = null;
            }
            return retResult;
        }

        public static int FromExcess3(string number)
        {
            int decimalNumber = 0;
            if (number.Length <= 4)
            {
                decimalNumber = ToBase10(2, number) - 3;
            }
            else
            {
                var len = number.Length;
                var newNumber = number.PadLeft(((len / 4 + 1) * 4), '0');
                var length = newNumber.Length;

                for (int i = 0; i < length; i += 4)
                {
                    decimalNumber = decimalNumber * 10 + ToBase10(2, newNumber.Substring(i, 4)) - 3;
                }
            }

            return decimalNumber;
        }

        public static string ToExcess3(int number)
        {
            string retResult = "";
            if (number > 12)
            {
                int[] result = new int[number.ToString().Length];
                int quotient = number, remainder = 0;
                int count = result.Length - 1;
                do
                {
                    remainder = quotient % 10;
                    quotient = quotient / 10;


                    result[count] = remainder + 3;
                    count--;
                } while (quotient > 0);

                var r = result.Aggregate<int>((x, y) => y + (x << 4));
                retResult = FromBase10(2, r);
            }
            else
            {
                retResult = FromBase10(2, number + 3);
            }
            return retResult;
        }

        public static int FromBCD(string number)
        {
            int decimalNumber = 0;
            var len = number.Length;
            string newNumber = number.PadLeft(((len / 4 + 1) * 4), '0');
            var length = newNumber.Length;
            for (int i = 0; i < length; i += 4)
            {
                decimalNumber = decimalNumber * 10 + ToBase10(2, newNumber.Substring(i, 4));
            }
            return decimalNumber;
        }

        public static string ToBCD(int number)
        {
            string[] result = new string[number.ToString().Length];
            int quotient = number, remainder = 0;
            int count = 0;
            do
            {
                remainder = quotient % 10;
                quotient = quotient / 10;

                result[count] = FromBase10(2, remainder).PadLeft(4, '0');
                count++;
            } while (quotient > 0);

            return result.Aggregate<string>((x, y) => y + "" + x);
        }

        public static string FromBase10(int newBase, int number)
        {
            StringBuilder newNumber = new StringBuilder();
            char[] hexDigits = new[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            int quotient = number, remainder = 0;
            do
            {
                remainder = quotient % newBase;
                quotient = quotient / newBase;
                if (remainder > 9)
                    newNumber.Append(hexDigits[remainder - 10]);
                else
                    newNumber.Append(remainder);
            } while (quotient > 0);

            var chArr = newNumber.ToString().ToCharArray();
            Array.Reverse(chArr);
            return new string(chArr);
        }

        public static int ToBase10(int numberBase, string number)
        {
            int decimalNumber = 0;
            int n = 0;
            char[] hexDigits = new[] { 'A', 'B', 'C', 'D', 'E', 'F' };
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] >= 48 && number[i] <= 57)
                {
                    n = number[i] - 48;
                }
                else if (number[i] >= 65 && number[i] <= 90)
                {
                    n = number[i] - 'A' + 10;
                }
                else if (number[i] >= 97 && number[i] <= 122)
                {
                    n = number[i] - 'a' + 10;
                }

                if (n < 0 || n >= numberBase)
                {
                    decimalNumber = -1;
                    break;
                }
                decimalNumber = decimalNumber * numberBase + n;
            }

            return decimalNumber;
        }
    }
}
