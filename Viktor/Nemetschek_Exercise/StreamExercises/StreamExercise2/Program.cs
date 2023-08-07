static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
{
    using (var stream = new StreamReader(inputFilePath))
    {
        var writer = new StreamWriter(outputFilePath, true);
        var line = stream.ReadLine();
        var i = 1;

        while (line != null)
        {
            writer.WriteLine($"{i}. {line}");
            i++;
            line = stream.ReadLine();
        }
        writer.Close();
    }
}

string inputFilePath = @"..\..\..\Files\input.txt";
string outputFilePath = @"..\..\..\Files\output.txt";

RewriteFileWithLineNumbers(inputFilePath, outputFilePath);