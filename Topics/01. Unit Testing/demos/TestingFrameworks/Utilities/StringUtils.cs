using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public class StringUtils
    {
        public bool ValidateString(string input, string pattern)
        {
            var match = Regex.Match(input, pattern);

            return match.Success;
        }
    }
}