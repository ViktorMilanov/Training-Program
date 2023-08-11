namespace StreamTask1
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"./input.txt";
            string outputFilePath = @"./output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader reader = new(inputFilePath))
            using (StreamWriter writer = new(outputFilePath))
            {
                string line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber % 2 == 0)
                    {
                        writer.WriteLine(line);
                    }

                    lineNumber++;
                }
            }

            Console.WriteLine("Odd lines extracted successfully.");
        }
    }
}