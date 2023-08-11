using SpellChecker;

string dictonaryPath = "./TextFiles/dictionary.txt";
string stopwordsPath = "./TextFiles/stopwords.txt";
string outputFilePath = @"..\..\..\TextFiles\output.txt";
string textFilePath = "./TextFiles/text.txt";
int suggestedWordsCount = 3;

StreamReader dictonaryReader = new StreamReader(dictonaryPath);
StreamReader stopwordsReader = new StreamReader(stopwordsPath);
StreamReader textReader = new StreamReader(textFilePath);
StreamWriter outputWriter = new StreamWriter(outputFilePath, true);

ISpellChecker spellChecker = new NaiveSpellChecker(dictonaryReader, stopwordsReader);
spellChecker.Analyze(textReader, outputWriter, suggestedWordsCount);    
