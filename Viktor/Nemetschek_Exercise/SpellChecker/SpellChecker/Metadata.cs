using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker
{
    public record Metadata(int Characters, int Words, Dictionary<string, int> mistakenWords);
}
