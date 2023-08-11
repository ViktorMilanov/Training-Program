using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Въведете текст:");
        string text = Console.ReadLine();

        string[] emailAddresses = ExtractEmailAddresses(text);

        Console.WriteLine("Извлечените e-mail адреси са:");
        foreach (string emailAddress in emailAddresses)
        {
            Console.WriteLine(emailAddress);
        }
    }

    static string[] ExtractEmailAddresses(string text)
    {
        string pattern = @"(?<=\s|^)[a-zA-Z0-9_.+-]{2,}@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+(?=\s|$)";

        MatchCollection matches = Regex.Matches(text, pattern);

        // Using lambda expression to extract email addresses from matches
        string[] emailAddresses = matches.Cast<Match>().Select(match => match.Value).ToArray();

        return emailAddresses;
    }
}
