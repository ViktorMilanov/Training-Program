using System.Collections.Generic;

namespace Filmify.Models
{
    public record MovieInfo : ISuggest
    {
        public List<int> genre_ids { get; set; }
        public List<string> genre_names { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public double vote_average { get; set; }

        public string release_date { get; set; }
        public string title { get; set; }
    }
}
