using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Calculator
{
    public interface ICalculator
    {
        IEnumerable<List<long>> Calculate(List<long> nums, long sum);
    }
}
