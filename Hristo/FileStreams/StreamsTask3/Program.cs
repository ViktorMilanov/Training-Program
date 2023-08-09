namespace StreamsTask3
{
    public class WordCount
    {
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            // Read the list of words from the words file
            List<string> words = File.ReadAllLines(wordsFilePath)
                                     .Select(word => word.ToLower())
                                     .ToList();

            // Read the text from the text file and convert to lowercase
            string text = File.ReadAllText(textFilePath).ToLower();

            // Split the text into words and count their occurrences
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                int count = CountWordOccurrences(text, word);
                wordCounts[word] = count;
            }

            // Sort words by frequency in descending order
            var sortedWordCounts = wordCounts.OrderByDescending(pair => pair.Value)
                                             .ThenBy(pair => pair.Key);

            // Write word counts to the output file
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var pair in sortedWordCounts)
                {
                    writer.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
        }

        private static int CountWordOccurrences(string text, string word)
        {
            int count = 0;
            int index = text.IndexOf(word);
            while (index != -1)
            {
                count++;
                index = text.IndexOf(word, index + word.Length);
            }
            return count;
        }
    }

    class Program
    {
        static void Main()
        {
            string wordsFilePath = @"./words.txt";
            string textFilePath = @"./text.txt";
            string outputFilePath = @"./output.txt";

            WordCount.CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);

            Console.WriteLine("Word counts calculated and written to the output file.");
        }
    }
}