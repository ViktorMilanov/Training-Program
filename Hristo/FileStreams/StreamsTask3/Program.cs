namespace StreamsTask3
{
    public class WordCount
    {
        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            List<string> words = File.ReadAllLines(wordsFilePath)
                                     .Select(word => word.ToLower())
                                     .ToList();

            string text = File.ReadAllText(textFilePath).ToLower();

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                int count = CountWordOccurrences(text, word);
                wordCounts[word] = count;
            }

            var sortedWordCounts = wordCounts.OrderByDescending(pair => pair.Value)
                                             .ThenBy(pair => pair.Key);

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