using DigitalConverterLex.BusinessLayer.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalConverterLex.Models
{
    public class SlotValues
    {
        public NumberType FromNumberType { get; set; }
        public NumberType ToNumberType { get; set; }
        public string CustomNumber { get; set; }
        public bool IsErrored { get; set; }
        public string Message { get; set; }

        private SlotValues()
        {
            IsErrored = false;
        }

        public static SlotValues GetInstance(string from, string to, string number)
        {
            var slotValues = new SlotValues();
            slotValues.FromNumberType = slotValues.GetNumberType(from);
            slotValues.ToNumberType = slotValues.GetNumberType(to);
            slotValues.IsErrored = slotValues.FromNumberType == NumberType.NULL || slotValues.ToNumberType == NumberType.NULL;
            if (slotValues.IsErrored)
            {
                slotValues.Message = "Sorry I didn't understood the number format. Please try again.";
            }
            else
            {
                var coreEngine = new CoreEngine();
                slotValues.Message = coreEngine.GetResult(number, slotValues.FromNumberType, slotValues.ToNumberType);
            }
            return slotValues;
        }

        private NumberType GetNumberType(string type)
        {
            NumberType numberType = NumberType.NULL;
            if (type != null)
                if (type.StartsWith("base"))
                {
                    var n = int.Parse(type.Replace("base ", ""));
                    numberType = (NumberType)n;
                }
                else if (type.Equals("binary", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.BASE2;
                else if (type.Equals("octal", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.BASE8;
                else if (type.Equals("hexadecimal", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.BASE16;
                else if (type.Equals("decimal", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.BASE10;
                else if (type.Equals("BCD", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.BCD;
                else if (type.Equals("Excess 3", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.EXCESS3;
                else if (type.Equals("1s compliment", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.COMPLEMENT1;
                else if (type.Equals("2s compliment", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.COMPLEMENT2;
                else if (type.Equals("9s compliment", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.COMPLEMENT9;
                else if (type.Equals("10s compliment", StringComparison.CurrentCultureIgnoreCase))
                    numberType = NumberType.COMPLEMENT10;
                else
                    numberType = NumberType.NULL;

            return numberType;
        }
    }
}
