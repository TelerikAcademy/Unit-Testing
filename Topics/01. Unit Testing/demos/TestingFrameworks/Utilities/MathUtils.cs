using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class MathUtils
    {
        public int Sum(IEnumerable<int> numbers)
        {
            var sum = numbers.Sum(x => x);
            return sum;
        }
    }
}
