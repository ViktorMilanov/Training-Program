using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class ChatRoomClass
    {
        public event EventHandler<ChatMessageEventArgs> MessageSend;

        public List<string> Participants { get; private set; }

        public string Name { get; set; }

        public ChatRoomClass(string name)
        {
            this.Name = name;
            Participants = new List<string>();
        }

        public void PublishMessage(string message, string username)
        {
            var messageArgs = new ChatMessageEventArgs(message, username);
            MessageSend(this, messageArgs);
        }

    }
}
