static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
{
    string text;
    Dictionary<string, int> wordCounts = new Dictionary<string, int>();

    using (StreamReader reader = new StreamReader(wordsFilePath))
    {
        var words = reader.ReadToEnd().Split(' ');
        foreach (var word in words)
        {
            wordCounts.Add(word,0);
        }
    }

    using (StreamReader reader = new StreamReader(textFilePath))
    {
        text = reader.ReadToEnd();
    }
    foreach (var word in wordCounts.Keys)
    {
        wordCounts[word] = CountSubstringOccurrences(text, word);
    }
    var orderedWords = from entry in wordCounts orderby entry.Value descending select entry;
    using (StreamWriter writer = new StreamWriter(outputFilePath, true))
    {
        foreach (var word in orderedWords)
        {
            writer.WriteLine($"{word.Key} - {word.Value}");
        }
    }
}

static int CountSubstringOccurrences(string text, string targetWord)
{
    text = text.ToLower();
    targetWord = targetWord.ToLower();
    string[] words = text.Split(new[] { "-", " ", ".", ",", "!", "?", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);

    int count = 0;
    foreach (string word in words)
    {
        if (word.Equals(targetWord, StringComparison.OrdinalIgnoreCase))
        {
            count++;
        }
    }

    return count;
}

string wordsFilePath = @"..\..\..\Files\words.txt";
string textFilePath = @"..\..\..\Files\text.txt";
string outputFilePath = @"..\..\..\Files\output.txt";

CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);