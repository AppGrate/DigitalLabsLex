using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalConverterLex.Models
{
    public class InputEventFormat
    {
        public Currentintent currentIntent { get; set; }
        public Bot bot { get; set; }
        public string userId { get; set; }
        public string inputTranscript { get; set; }
        public string invocationSource { get; set; }
        public string outputDialogMode { get; set; }
        public string messageVersion { get; set; }
        public object sessionAttributes { get; set; }
    }

    public class Currentintent
    {
        public string name { get; set; }
        public Dictionary<string,string> slots { get; set; }
        public string confirmationStatus { get; set; }
    }

    public class Slots
    {
        public string slotname { get; set; }
    }

    public class Bot
    {
        public string name { get; set; }
        public string alias { get; set; }
        public string version { get; set; }
    }

    public class Sessionattributes
    {
        public string key1 { get; set; }
        public string key2 { get; set; }
    }
}
