using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DigitalConverterLex.BusinessLayer.Strategy
{
    public class CoreEngine
    {

        public string GetResult(string number, NumberType from, NumberType to)
        {
            Result result = null;
            if ((int)from <= 16 && (int)to <= 16)
            {
                result = NumberConverter.EvaluateCustom((int)from, (int)to, number);
            }
            //else
            //{
            //    result = NumberConverter.EvaluateStandard(from, to, number);
            //}
            else if ((int)from <= 16)
            {
                var temp = NumberConverter.EvaluateCustom((int)from, 10, number);
                if (!temp.IsError)
                    result = NumberConverter.EvaluateStandard(NumberType.BASE10, to, temp.Output);
                else
                    result = temp;
            }
            else if ((int)to <= 16)
            {
                var temp = NumberConverter.EvaluateStandard(from, NumberType.BASE10, number);
                if (!temp.IsError)
                    result = NumberConverter.EvaluateCustom(10, (int)to, number);
                else
                    result = temp;
            }
            else
            {
                var temp = NumberConverter.EvaluateStandard(from, NumberType.BASE10, number);
                if (!temp.IsError)
                    result = NumberConverter.EvaluateStandard(NumberType.BASE10, to, temp.Output);
                else
                    result = temp;
            }

            var speech = "Sorry please try again later.";
            if (result != null)
            {
                //if (to == NumberType.COMPLEMENT1 || to == NumberType.COMPLEMENT9)
                //    speech = result.Output1;
                //else if (to == NumberType.COMPLEMENT2 || to == NumberType.COMPLEMENT10)
                //    speech = result.Output2;
                //else
                speech = result.Output;

                if (!result.IsError)
                {
                    if (result.Output.Length > 3 || to != NumberType.BASE10)
                    {
                        //speech = $"The answer is: {string.Join(", ", speech.ToArray())}";
                        speech = $"The answer is: {speech}";
                    }
                }
            }

            return speech;
        }
    }
}
