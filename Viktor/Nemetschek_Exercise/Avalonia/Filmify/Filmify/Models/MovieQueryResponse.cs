using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
