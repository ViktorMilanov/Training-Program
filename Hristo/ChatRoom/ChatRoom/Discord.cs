﻿namespace ChatRoom
{
    public class DiscordClient
    {
        public string User { get; private set; }
        public DiscordClient(string user)
        {
            User = user;
        }
        public void JoinChatRoom(ChatRoom room)
        {
            room.MessageSend += this.OnMessageResieved;
        }
        public void SendMessage(ChatRoom room, string content)
        {
            room.PublishMessage(this.User, content);
        }
        protected void OnMessageResieved(object sender, ChatMessagesEventArgs args)
        {
            Console.WriteLine(($@"{this.User} just recieved the message:
               ${args.Author} - ${args.SentTimestamp} : ${args.Content}"));
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}
