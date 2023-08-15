using System.Text;
using System.Text.RegularExpressions;

namespace Spellchecker
{
    class Program
    {
        static void Main(string[] args)
        {
            string dictionaryFilePath = "./dictionary.txt";
            string stopwordsFilePath = "./stopwords.txt";
            string inputTextFilePath = "./input_text.txt";
            string outputFilePath = "./output.txt";

            using (StreamReader dictionaryReader = new(dictionaryFilePath))
            using (StreamReader stopwordsReader = new(stopwordsFilePath))
            using (StreamReader inputTextReader = new(inputTextFilePath))
            using (StreamWriter outputWriter = new(outputFilePath))
            {
                var spellChecker = new NaiveSpellChecker(dictionaryReader, stopwordsReader);
                spellChecker.Analyze(inputTextReader, outputWriter, 3);
            }
        }
    }
    public record Metadata(int Characters, int Words, int Mistakes);

    public class NaiveSpellChecker
    {
        private readonly HashSet<string> dictionary;
        private readonly HashSet<string> stopwords;

        public NaiveSpellChecker(StreamReader dictionaryReader, StreamReader stopwordsReader)
        {
            dictionary = new HashSet<string>(ReadWordList(dictionaryReader));
            stopwords = new HashSet<string>(ReadWordList(stopwordsReader));
        }

        public void Analyze(StreamReader textReader, StreamWriter output, int suggestionsCount)
        {
            int lineNumber = 0;
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                lineNumber++;
                var words = SplitIntoWords(line);
                var misspelledWords = words.Where(w => IsMisspelled(w)).ToList();

                if (misspelledWords.Any())
                {
                    output.WriteLine(line);
                    output.WriteLine("= = = Metadata = = =");
                    var metadata = Metadata(new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(line))));
                    output.WriteLine($"{metadata.Characters} characters, {metadata.Words} words, {misspelledWords.Count} spelling issue(s) found");
                    output.WriteLine("= = = Findings = = =");
                    for (int i = 0; i < misspelledWords.Count; i++)
                    {
                        var suggestions = FindClosestWords(misspelledWords[i], suggestionsCount);
                        output.WriteLine($"Line #{lineNumber}, {{{misspelledWords[i]}}} - Possible suggestions are {{{string.Join(", ", suggestions)}}}");
                    }
                    output.WriteLine();
                }
            }
        }


        public Metadata Metadata(StreamReader textReader)
        {
            textReader.BaseStream.Position = 0;
            var text = textReader.ReadToEnd();
            int characters = text.Length;
            int words = SplitIntoWords(text).Count;
            int mistakes = SplitIntoWords(text).Count(IsMisspelled);
            return new Metadata(characters, words, mistakes);
        }

        public IList<string> FindClosestWords(string word, int n)
        {
            var wordNgrams = GenerateNgrams(word, 2);
            var closestWords = dictionary
                .OrderByDescending(dictWord => CalculateCosineSimilarity(wordNgrams, GenerateNgrams(dictWord, 2)))
                .Take(n)
                .ToList();
            return closestWords;
        }

        private bool IsMisspelled(string word)
        {
            string cleanedWord = CleanWord(word);
            return !stopwords.Contains(cleanedWord) && !dictionary.Contains(cleanedWord);
        }

        private List<string> ReadWordList(StreamReader reader)
        {
            var words = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string cleanWord = CleanWord(line);
                if (!string.IsNullOrEmpty(cleanWord))
                {
                    words.Add(cleanWord);
                }
            }
            return words;
        }

        private string CleanWord(string word)
        {
            string cleanedWord = word.Trim().ToLower();
            cleanedWord = Regex.Replace(cleanedWord, "[^a-zA-Z]", "");
            return cleanedWord;
        }

        private List<string> SplitIntoWords(string text)
        {
            return text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(w => CleanWord(w))
                       .Where(w => !string.IsNullOrEmpty(w))
                       .ToList();
        }

        private List<string> GenerateNgrams(string word, int n)
        {
            var ngrams = new List<string>();
            for (int i = 0; i <= word.Length - n; i++)
            {
                ngrams.Add(word.Substring(i, n));
            }
            return ngrams;
        }

        private double CalculateCosineSimilarity(List<string> vector1, List<string> vector2)
        {
            var intersection = vector1.Intersect(vector2).ToList();
            double dotProduct = intersection.Count;
            double magnitude1 = Math.Sqrt(vector1.Count);
            double magnitude2 = Math.Sqrt(vector2.Count);
            return dotProduct / (magnitude1 * magnitude2);
        }
    }
}
