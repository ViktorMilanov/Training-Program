using System.Collections.Generic;

namespace Filmify.Models
{
    public record SeriesInfo : ISuggest
    {
        public List<int> genre_ids { get; set; }
        public List<string> genre_names { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public double vote_average { get; set; }

        public string first_air_date { get; set; }
        public string name { get; set; }

    }
}