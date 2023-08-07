using System.Text.RegularExpressions;

static string[] GetEmails(string expresion)
{
    return Regex.Matches(expresion, @"(?<=\s|^)[a-zA-Z0-9_.+-]{2,}@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+(?=\s|$)")
    .Cast<Match>()
    .Select(m => m.Value)
    .ToArray();
}
var arr = GetEmails("Please contact us by phone (+359 222 222 222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email: test@test. This also: @softuni.bg.com. Neither this: a@a.b. ");
foreach (string email in arr)
{
    Console.WriteLine(email);
}