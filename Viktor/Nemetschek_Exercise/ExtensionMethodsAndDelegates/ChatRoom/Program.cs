using ChatRoom;
ChatRoomClass ChatRoom = new ChatRoomClass("Viktor's chat");

var gosho = new SkypeClient("gosho");
var tosho = new DiscordClient("tosho");
 
gosho.JoinChatRoom(ChatRoom);
tosho.JoinChatRoom(ChatRoom);

gosho.SendMessage(ChatRoom, "ZDR");
tosho.SendMessage(ChatRoom, "Chao");

Console.WriteLine(tosho.History);