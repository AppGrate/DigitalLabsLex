using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using DigitalConverterLex.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DigitalConverterLex
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public ResponseFormat FunctionHandler(InputEventFormat input, ILambdaContext context)
        {
            var responseFormat = new ResponseFormat();
            if (input.currentIntent?.name?.Equals("NumberConversion", StringComparison.CurrentCultureIgnoreCase) ?? false)
            {
                responseFormat.dialogAction.type = "Close";
                responseFormat.dialogAction.message.contentType = "PlainText";
                responseFormat.dialogAction.fulfillmentState = "Fulfilled";

                var slotValues = SlotValues.GetInstance(input.currentIntent.slots["FromNumberType"], input.currentIntent.slots["ToNumberType"], input.currentIntent.slots["CustomNumber"]);
                if (slotValues.IsErrored)
                {
                    responseFormat.dialogAction.message.content = slotValues.Message;
                }
                else
                {
                    responseFormat.dialogAction.message.content = slotValues.Message;
                }
            }
            return responseFormat;
        }
    }
}
