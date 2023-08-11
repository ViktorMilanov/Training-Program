namespace StreamsTask2
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"./input.txt";
            string outputFilePath = @"./output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new(inputFilePath))
            using (StreamWriter writer = new(outputFilePath))
            {
                string line;
                int lineNumber = 1;

                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine($"{lineNumber}: {line}");
                    lineNumber++;
                }
            }

            Console.WriteLine("File with line numbers written successfully.");
        }
    }
}