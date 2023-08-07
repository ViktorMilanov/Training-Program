using HtmlAgilityPack;

HtmlDocument htmlText = new HtmlDocument();
htmlText.LoadHtml(@"
            <html> 
                <head><title>News</title></head> 
                <body><p><a href='https://softuni.bg'>Telerik Academy</a> aims to provide free real-world practical training for young people who want to turn into skillful .NET software engineers.</p></body> 
            </html>");

string title = htmlText.DocumentNode.SelectSingleNode("//title").InnerText.Trim();
string body = htmlText.DocumentNode.SelectSingleNode("//body").InnerText.Trim();
string telerikAcademyText = htmlText.DocumentNode.SelectSingleNode("//a").InnerText.Trim();//xpath

Console.WriteLine("Title: " + title);
Console.WriteLine("Body:\n" + body);
Console.WriteLine("Telerik Academy: " + telerikAcademyText);