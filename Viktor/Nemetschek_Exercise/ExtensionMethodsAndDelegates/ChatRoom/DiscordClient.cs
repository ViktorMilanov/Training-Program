using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class DiscordClient
    {
        public string User { get; set; }
        private List<string> history;
        public string History 
        { 
            get 
            {
                return string.Join("\r\n", this.history);            
            } 
        }
        public DiscordClient(string user)
        {
            this.User = user;
            history = new List<string>();
        }

        public void JoinChatRoom(ChatRoomClass room)
        {
            room.MessageSend += this.OnMessageReceived;
        }

        public void SendMessage(ChatRoomClass room, string content)
        {
            room.PublishMessage(content, this.User);
        }

        protected void OnMessageReceived(object sender, ChatMessageEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"[{this.User}] received message: {args.Author} - {args.TimeOn}: {args.Message}");
            this.history.Add(args.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}