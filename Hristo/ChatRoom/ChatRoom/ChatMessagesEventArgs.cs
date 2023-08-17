namespace ChatRoom
{
    public class ChatMessagesEventArgs : EventArgs
    {
        public string Content { get; private set; }

        public DateTime SentTimestamp { get; private set; }

        public string Author { get; set; }

        public ChatMessagesEventArgs(string content, string author)
        {
            Content = content;
            SentTimestamp = DateTime.Now;
            Author = author;
        }
    }
}
