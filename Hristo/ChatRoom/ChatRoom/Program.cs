using System;
using System.Collections.Generic;

namespace ChatRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoom room = new("General Chat");

            XClient client1 = new("User1");
            XClient client2 = new("User2");

            client1.JoinChatRoom(room);
            client2.JoinChatRoom(room);

            room.MessageSend += (sender, eventArgs) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"New message in {room.Name}!");
                Console.ResetColor();
            };

            client1.SendMessage(room, "Hello, everyone!");
            client2.SendMessage(room, "Hey there!");

            Console.ReadLine();
        }
    }
}
