using System;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        string html = @"
            <html>
                <head><title>News</title></head>
                <body><p><a href='https://softuni.bg'>Telerik
                    Academy</a>aims to provide free real-world practical
                    training for young people who want to turn into
                    skillful .NET software engineers.</p></body>
            </html>";

        string extractedText = ExtractTextFromHtml(html);
        Console.WriteLine(extractedText);
    }

    static string ExtractTextFromHtml(string html)
    {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);

        string title = doc.DocumentNode.SelectSingleNode("//title")?.InnerText;
        string body = doc.DocumentNode.SelectSingleNode("//body")?.InnerText;

        string extractedText = "Title: " + title + Environment.NewLine +
                               "Body:" + Environment.NewLine + body.Trim();

        return extractedText;
    }
}
