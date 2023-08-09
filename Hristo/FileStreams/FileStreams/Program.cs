using System.Text;

class Program
{
    static void Main()
    {
        File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "пренаредено_стихотворение.txt"), string.Join(" ", File.ReadAllText("./poem.txt").Split(new[] { ' ', '\t', '\n', '\r', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).OrderBy(word => word, StringComparer.CurrentCultureIgnoreCase)), new UTF8Encoding(true));
    }
}
