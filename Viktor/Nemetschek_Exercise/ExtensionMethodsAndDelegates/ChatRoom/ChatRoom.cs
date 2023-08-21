using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class ChatRoomClass
    {
        public event EventHandler<ChatMessageEventArgs> SendMessage;

        public string Name { get; set; }

        public ChatRoomClass(string name)
        {
            this.Name = name;
        }

        public void PublishMessage(string message, string username)
        {
            var messageArgs = new ChatMessageEventArgs(message, username);
            SendMessage(this, messageArgs);
        }

    }
}
