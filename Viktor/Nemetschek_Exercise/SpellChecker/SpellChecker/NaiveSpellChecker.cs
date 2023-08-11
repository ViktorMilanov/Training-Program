using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpellChecker
{
    public class NaiveSpellChecker : ISpellChecker
    {
        private HashSet<string> dictionary;
        private HashSet<string> stopwords;

        /**
 * Creates a new instance of NaiveSpellCheckTool, based on a dictionary of words and stop words
 *
 * @param dictionary a StreamReader input stream containing list of words which will serve as a dictionary for the tool
 * @param stopwords a StreamReader input stream containing list of stopwords
 */
        public NaiveSpellChecker(StreamReader dictionaryReader, StreamReader stopwordsReader)
        {
            dictionary = new HashSet<string>();
            stopwords = new HashSet<string>();

            FillTheHashSet(dictionaryReader, dictionary);
            FillTheHashSet(stopwordsReader, stopwords);
        }

        private void FillTheHashSet(StreamReader dictionaryReader, HashSet<string> dictionary)
        {
            using (dictionaryReader)
            {
                string line;
                while ((line = dictionaryReader.ReadLine()) != null)
                {
                    dictionary.Add(line.ToLower());
                }
            }
        }

        public void Analyze(StreamReader textReader, StreamWriter output, int suggestionsCount)
        {
            string text = ReadingTextFormReader(textReader);
            string[] textByLines = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var metadata = Metadata(textByLines);
            Dictionary<string, IList<string>> suggestedWords = new Dictionary<string, IList<string>>();
            foreach (var mistakenWord in metadata.mistakenWords.Keys)
            {
                suggestedWords.Add(mistakenWord, FindClosestWords(mistakenWord, suggestionsCount));
            }
            using (StreamWriter outputWriter = new StreamWriter(output.BaseStream, output.Encoding))
            {
                foreach (var line in textByLines)
                {
                    outputWriter.WriteLine(line);
                }
                outputWriter.WriteLine("= = = Metadata = = =");
                outputWriter.WriteLine($"{metadata.Characters} characters, {metadata.Words} words, {metadata.mistakenWords.Count} spelling issue(s) found");
                outputWriter.WriteLine("= = = Findings = = =");
                foreach (var word in suggestedWords.Keys)
                {
                    IList<string> suggests = suggestedWords[word];
                    string suggestionsStr = string.Join(", ", suggests);

                    outputWriter.WriteLine($"Line #{metadata.mistakenWords[word]}, {word} - Possible suggestions are {{{suggestionsStr}}}");
                }
               
            }
        }

        public IList<string> FindClosestWords(string word, int n)
        {
            Dictionary<string, double> mostSimilarSuggestedWord = new Dictionary<string, double>();
            Dictionary<string, int> mispelenWordVector = new Dictionary<string, int>();
            mispelenWordVector = FindVectorOfWord(word);
            double lenghtOfMispelenWordVector = FindLenghtOfVector(mispelenWordVector);
            foreach (var suggest in dictionary)
            {
                double cosSimilarity = FindSimirarity(suggest, lenghtOfMispelenWordVector, mispelenWordVector);
                FindTheBestSuggests(n, suggest, cosSimilarity, mostSimilarSuggestedWord);
            }
            return mostSimilarSuggestedWord.Keys.ToList();
        }

        private void FindTheBestSuggests(int n, string suggest, double cosSimilarity, Dictionary<string, double> mostSimilarSuggestedWord)
        {
            if (mostSimilarSuggestedWord.Count < n)
            {
                mostSimilarSuggestedWord.Add(suggest, cosSimilarity);
            }
            else
            {
                string minSimilarityKey = mostSimilarSuggestedWord.OrderBy(kvp => kvp.Value).First().Key;
                if (cosSimilarity > mostSimilarSuggestedWord[minSimilarityKey])
                {
                    mostSimilarSuggestedWord.Remove(minSimilarityKey);
                    mostSimilarSuggestedWord.Add(suggest, cosSimilarity);
                }
            }
        }


        private double FindSimirarity(string suggest, double lenghtOfMispelenWordVector, Dictionary<string, int> mispelenWordVector)
        {
            Dictionary<string, int> suggestWordVector = new Dictionary<string, int>();
            suggestWordVector = FindVectorOfWord(suggest);
            double lenghtOfSuggestedWordVector = FindLenghtOfVector(mispelenWordVector);
            var commonKeys = mispelenWordVector.Keys.Intersect(suggestWordVector.Keys);
            double vectorProduct = 0;
            foreach (var key in commonKeys)
            {
                vectorProduct += mispelenWordVector[key] * suggestWordVector[key];
            }
            return vectorProduct / (lenghtOfMispelenWordVector * lenghtOfSuggestedWordVector);
        }

        private double FindLenghtOfVector(Dictionary<string, int> mispelenWordVector)
        {
            return Math.Sqrt(mispelenWordVector.Values.Sum(value => value * value));
        }

        private Dictionary<string, int> FindVectorOfWord(string word)
        {
            Dictionary<string, int> vectorDictionary = new Dictionary<string, int>();

            for (int i = 0; i < word.Length - 1; i++)
            {
                string gram = word.Substring(i, 2);

                if (vectorDictionary.ContainsKey(gram))
                {
                    vectorDictionary[gram]++;
                }
                else
                {
                    vectorDictionary[gram] = 1;
                }
            }

            return vectorDictionary;
        }

        public Metadata Metadata(string[] textByLines)
        {
            int wordCount = 0, charactersCount = 0;
            Dictionary<string, int> mistakenWords = new Dictionary<string, int>();
            for (int i = 0; i < textByLines.Length; i++)
            {
                char[] delimiters = { ' ', '.', ',', '!', '?', ';', ':', '(', ')', '[', ']', '{', '}', '<', '>'};
                string[] wordsInLine = textByLines[i]
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                foreach (var word in wordsInLine)
                {
                    if (stopwords.Contains(word.ToLower()) || IsOnlyNonAlphabetic(word))
                    {
                        continue;
                    }
                    wordCount++;
                    charactersCount += word.Length;
                    if (!dictionary.Contains(word.ToLower()))
                    {
                        mistakenWords.Add(word.ToLower(), i + 1);
                    }
                }
            }
            return new Metadata(charactersCount, wordCount, mistakenWords);
        }

        private string ReadingTextFormReader(StreamReader textReader)
        {
            string text = "";
            string line;
            while ((line = textReader.ReadLine()) != null)
            {
                text += line.ToLower() + Environment.NewLine;
            }

            textReader.BaseStream.Seek(0, SeekOrigin.Begin);
            textReader.DiscardBufferedData();

            return text;
        }

        static bool IsOnlyNonAlphabetic(string input)
        {
            return Regex.IsMatch(input, @"^[^a-zA-Z]*$");
        }
    }
}
