using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class ChatMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime TimeOn { get; set; }

        public ChatMessageEventArgs(string message, string author)
        {
            this.Message = message;
            this.Author = author;
            this.TimeOn = DateTime.Now;
        }
    }
}
