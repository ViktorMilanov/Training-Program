using System.Text;

string resourceName = "./poem.txt";

var fileName = Path.Combine(Environment.GetFolderPath(
Environment.SpecialFolder.ApplicationData), "AlphabeticPoem.txt");

string poem;

using (Stream stream = File.OpenRead(resourceName))
{
    if (stream == null)
    {
        Console.WriteLine("Input resource not found. Make sure to set the correct namespace and file name.");
        return;
    }



    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
    {
        poem = reader.ReadToEnd();
    }
}
char[] delimiters = { ' ', '\n', '\r', '.', ',', ':', '-', '!', '?', '(', ')', '"', ';', '—' };

string alphabeeticPoem = string.Join(" ",
    poem.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
        .SelectMany(word => word.Split(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }))
        .OrderBy(w => w, StringComparer.OrdinalIgnoreCase)
);
using (StreamWriter streamWriter = new StreamWriter(fileName, false, Encoding.UTF8))
{
    streamWriter.WriteLine(alphabeeticPoem);
}