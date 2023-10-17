using System.Collections.Generic;

namespace Filmify.Models
{
    public class MovieQueryResponse
    {
        public int page { get; set; }
        public List<MovieInfo> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
