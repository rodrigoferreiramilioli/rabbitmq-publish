using System;
using System.Collections.Generic;
using System.Text;

namespace consumidorrabbit
{
    public class MessageTransport
    {
        public MessageTransport()
        {
            message = "";
            nomeleitura = "";
            define = 0;
        }
        public string message { get; set; }
        public string nomeleitura { get; set; }
        public Guid guid { get; set; }
        public int define { get; set; }
    }
}
