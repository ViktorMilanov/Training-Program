using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmify.Models
{
    public record Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
