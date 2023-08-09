using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете символен низ:");
        string input = Console.ReadLine();

        string reversed = ReverseString(input);
        Console.WriteLine("Обърнатият низ е: " + reversed);
    }

    static string ReverseString(string input)
    {
        char[] characters = input.ToCharArray();
        Array.Reverse(characters);
        return new string(characters);
    }
}

//TODO: implement without using existing methods