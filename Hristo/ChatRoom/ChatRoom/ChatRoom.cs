namespace ChatRoom
{
    public class ChatRoom
    {
        public event EventHandler<ChatMessagesEventArgs> MessageSend;
        public List<string> Participants { get; set; }    
        public string  Name { get; private set; }
        public ChatRoom(string name)
        {
            Name = name;
        }
        public void PublishMessage(string message, string username)
        {
            var messageArgs = new ChatMessagesEventArgs(message, username);
            this.MessageSend(this, messageArgs);
        }
    }
}
