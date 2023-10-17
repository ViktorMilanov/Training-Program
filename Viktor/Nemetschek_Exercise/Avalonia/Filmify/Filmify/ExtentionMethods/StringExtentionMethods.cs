using System.Collections.Generic;

namespace Filmify.ExtentionMethods
{
    public static class StringExtentionMethods
    {
        public static string ReplaceInTemplate(this string text, List<string> wantedGenres, int numberOfThePage)
        {
            string wantedGenresQuery = string.Join("%2C", wantedGenres);
            return text.Replace("[WantedGenre]", wantedGenresQuery).Replace("[numberOfThePage]", numberOfThePage.ToString());
        }
    }
}
