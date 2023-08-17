using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom
{
    public class SkypeClient
    {
        public string User { get; set; }

        public SkypeClient(string user)
        {
            this.User = user;
        }

        public void JoinChatRoom(ChatRoomClass room)
        {
            room.SendMessage += this.OnMessageReceived;
        }

        public void SendMessage(ChatRoomClass room, string content)
        {
            room.PublishMessage(content, this.User);
        }

        protected void OnMessageReceived(object sender, ChatMessageEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[{this.User}] received message: {args.Author} - {args.TimeOn}: {args.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
