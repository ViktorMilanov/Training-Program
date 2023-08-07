static void ExtractOddLines(string inputFilePath, string outputFilePath)
{
    using (var stream = new StreamReader(inputFilePath))
    {
        var line = stream.ReadLine();
        var i = 0;

        while (line != null)
        {
            if (i % 2 != 0)
            {
                using (var writer = new StreamWriter(outputFilePath, true))
                {
                    writer.WriteLine(line);
                }
            }
            i++;
            line = stream.ReadLine();
        }
    }
}

string inputFilePath = @"..\..\..\Files\input.txt";
string outputFilePath = @"..\..\..\Files\output.txt";

ExtractOddLines(inputFilePath, outputFilePath);