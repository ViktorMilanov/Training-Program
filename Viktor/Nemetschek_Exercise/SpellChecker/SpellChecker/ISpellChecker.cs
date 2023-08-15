using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    public interface ISpellChecker
    {

        /**
         * Analyzes the text contained in {@code textReader} for spelling mistakes and outputs the result in {@code output}
         * The format of the analisis depends on the concrete implemetation.
         * 
         * @param textReader an input stream containing some text
         * @param output an output stream containing the analysis result
         * @param suggestionsCount The number of suggestions to be generated for each misspelled word in the text
         */
        void Analyze(StreamReader textReader, StreamWriter output, int suggestionsCount);

        /**
         * Returns the metadata of the text contained in {@code textReader}
         * The metadata gives information about the number of characters, words, and spelling mistakes in the text
         * @param textReader a stream containing some text
         * @return Metadata for the given text
         */
        Metadata Metadata(string[] textByLines);

        /**
         * Returns {@code n} closest words to {@code word}, sorted in descending order. 
         * The algorithm used for computing the similarity between words depends on the concrete implementation.
         * @param word
         * @param n
         * @return A List of {@code n} closest words to {@code word}, sorted in descending order
         */
        IList<string> FindClosestWords(string word, int n);

    }
}
