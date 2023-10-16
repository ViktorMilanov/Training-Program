using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmify.Models
{
    public interface ISuggest
    {
        public List<int> genre_ids { get; set; }
        public List<string> genre_names { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public double vote_average { get; set; }

    }
}
