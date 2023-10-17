using System.Collections.Generic;

namespace Filmify.Models
{
    public class SeriesQueryResponse
    {
        public int page { get; set; }
        public List<SeriesInfo> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
