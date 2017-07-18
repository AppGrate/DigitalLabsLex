using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalConverterLex.BusinessLayer.Strategy
{
    public static class NumberConverter
    {
        public static Result EvaluateStandard(NumberType from, NumberType to, string number)
        {
            var result = new Result();
            int decimalNumber = GetDecimalNumber(from, number);
            if (decimalNumber >= 0)
            {
                if (to == NumberType.COMPLEMENT1 || to == NumberType.COMPLEMENT2)
                {
                    var binaryNumber = DecimalNumber.FromBase10(2, decimalNumber);
                    result.Output = DecimalNumber.FindComplement(GetComplementType(to), binaryNumber, 2);
                }
                else if (to == NumberType.COMPLEMENT9 || to == NumberType.COMPLEMENT10)
                {
                    result.Output = DecimalNumber.FindComplement(GetComplementType(to), number, 10);
                }
                else
                {
                    result.Output = GetConvertedValue(to, decimalNumber);
                }
                //SourceBase = GetBaseString(from);
                //TargetBase = GetBaseString(to);
            }
            else
            {
                result.IsError = true;
                result.Output = $"Wrong {from}";
                //SourceValue = "-";
                //ConvertedValue = "-";
            }
            return result;
        }

        public static Result EvaluateCustom(int fromBase, int toBase, string number)
        {
            var result = new Result();
            result.ToBase = toBase;
            var decimalNumber = DecimalNumber.ToBase10(fromBase, number);
            if (decimalNumber >= 0)
            {
                result.Output = DecimalNumber.FromBase10(toBase, decimalNumber);
                result.Output1 = DecimalNumber.FindComplement(toBase - 1, result.Output, toBase);
                result.Output2 = DecimalNumber.FindComplement(toBase, result.Output, toBase);
            }
            else
            {
                result.IsError = true;
                result.Output = $"This is not a Base {fromBase} number";
            }
            return result;
        }

        private static string GetConvertedValue(NumberType numberType, int decimalNumber)
        {
            string retValue = null;
            switch (numberType)
            {
                case NumberType.BASE2:
                    retValue = DecimalNumber.FromBase10(2, decimalNumber);
                    break;

                case NumberType.BASE8:
                    retValue = DecimalNumber.FromBase10(8, decimalNumber);
                    break;

                case NumberType.BASE10:
                    retValue = DecimalNumber.FromBase10(10, decimalNumber);
                    break;

                case NumberType.BASE16:
                    retValue = DecimalNumber.FromBase10(16, decimalNumber);
                    break;

                case NumberType.BCD:
                    retValue = DecimalNumber.ToBCD(decimalNumber);
                    break;

                case NumberType.EXCESS3:
                    retValue = DecimalNumber.ToExcess3(decimalNumber);
                    break;

                default:
                    retValue = null;
                    break;
            }
            return retValue;
        }

        private static string GetBaseString(NumberType numberType)
        {
            string retValue = "";
            switch (numberType)
            {
                case NumberType.BCD:
                    retValue = "bcd";
                    break;

                case NumberType.EXCESS3:
                    retValue = "ex-3";
                    break;

                case NumberType.COMPLEMENT1:
                    retValue = "1s";
                    break;

                case NumberType.COMPLEMENT2:
                    retValue = "2s";
                    break;

                case NumberType.COMPLEMENT9:
                    retValue = "9s";
                    break;

                case NumberType.COMPLEMENT10:
                    retValue = "10s";
                    break;

                default:
                    retValue = ((int)numberType).ToString();
                    break;
            }
            return retValue;
        }

        private static int GetComplementType(NumberType numberType)
        {
            int complementType;
            switch (numberType)
            {
                case NumberType.COMPLEMENT1:
                    complementType = 1;
                    break;

                case NumberType.COMPLEMENT2:
                    complementType = 2;
                    break;

                case NumberType.COMPLEMENT9:
                    complementType = 9;
                    break;

                case NumberType.COMPLEMENT10:
                    complementType = 10;
                    break;

                default:
                    complementType = -1;
                    break;
            }
            return complementType;
        }

        private static int GetDecimalNumber(NumberType numberType, string number)
        {
            int decimalNumber = -1;
            switch (numberType)
            {
                case NumberType.BASE2:
                    decimalNumber = DecimalNumber.ToBase10(2, number);
                    break;

                case NumberType.BASE8:
                    decimalNumber = DecimalNumber.ToBase10(8, number);
                    break;

                case NumberType.BASE10:
                    decimalNumber = DecimalNumber.ToBase10(10, number);
                    break;

                case NumberType.BASE16:
                    decimalNumber = DecimalNumber.ToBase10(16, number);
                    break;

                case NumberType.BCD:
                    decimalNumber = DecimalNumber.FromBCD(number);
                    break;

                case NumberType.EXCESS3:
                    decimalNumber = DecimalNumber.FromExcess3(number);
                    break;

                default:
                    decimalNumber = -1;
                    break;
            }
            return decimalNumber;
        }
    }
}
