using System.Collections.Generic;
using System.Linq;

namespace IntergalacticTravel.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumeration)
        {
            return enumeration == null ||
                enumeration.Count() == 0;
        }
    }
}
