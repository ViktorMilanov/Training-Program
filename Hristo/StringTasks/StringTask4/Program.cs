using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете текст:");
        string text = Console.ReadLine();

        Console.WriteLine("Въведете подниз:");
        string substring = Console.ReadLine();

        int count = CountSubstringOccurrences(text, substring);
        Console.WriteLine("Резултатът е " + count + " срещания.");
    }

    static int CountSubstringOccurrences(string text, string substring)
    {
        int count = 0;

        for (int i = 0; i <= text.Length - substring.Length; i++)
        {
            if (IsMatch(text, i, substring))
            {
                count++;
            }
        }

        return count;
    }

    static bool IsMatch(string text, int startIndex, string substring)
    {
        for (int i = 0; i < substring.Length; i++)
        {
            if (text[startIndex + i] != substring[i])
            {
                return false;
            }
        }

        return true;
    }
}
//TODO implement without existing methods DONE