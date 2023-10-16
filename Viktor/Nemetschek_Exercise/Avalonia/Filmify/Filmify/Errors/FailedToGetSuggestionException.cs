using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmify.Errors
{
    public class FailedToGetSuggestionException : Exception
    {
        public FailedToGetSuggestionException(string message)
        : base(message)
        {
        }
    }
}
