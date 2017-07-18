using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalConverterLex.Models
{
    public class ResponseFormat
    {
        public object sessionAttributes { get; set; }
        public Dialogaction dialogAction { get; set; }
        public ResponseFormat()
        {
            dialogAction = new Dialogaction();
        }
    }

    public class Dialogaction
    {
        public string type { get; set; }
        public string fulfillmentState { get; set; }
        public Message message { get; set; }
        public Responsecard responseCard { get; set; }
        public Dialogaction()
        {
            message = new Message();
        }
    }

    public class Message
    {
        public string contentType { get; set; }
        public string content { get; set; }
    }

    public class Responsecard
    {
        public float version { get; set; }
        public string contentType { get; set; }
        public Genericattachment[] genericAttachments { get; set; }
    }

    public class Genericattachment
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public string imageUrl { get; set; }
        public string attachmentLinkUrl { get; set; }
        public Button[] buttons { get; set; }
    }

    public class Button
    {
        public string text { get; set; }
        public string value { get; set; }
    }

}
