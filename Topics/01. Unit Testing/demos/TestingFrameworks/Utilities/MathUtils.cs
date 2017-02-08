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
            if(numbers == null)
            {
                throw new ArgumentException();
            }

            if(numbers.Count() == 0)
            {
                return 1;
            }

            var sum = numbers.Sum(x => x);

            return sum;
        }
    }
}
