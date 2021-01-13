using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Calculator
{
    public class FakeForUTCalculator : ICalculator
    {
        public IEnumerable<List<long>> Calculate(List<long> nums, long sum)
        {
            var nums3 = nums.Take(3).ToList();
            long a = nums3[0];
            long b = nums3[1];
            long c = nums3[2];
            if (a == sum)
                yield return new List<long>() { a };
            if (b == sum)
                yield return new List<long>() { b };
            if (c == sum)
                yield return new List<long>() { c };
            if (a + b == sum)
                yield return new List<long>() { a, b };
            if (a + c == sum)
                yield return new List<long>() { a, c };
            if (b + c == sum)
                yield return new List<long>() { b, c };
            if (a + b + c == sum)
                yield return new List<long>() { a, b, c };
        }
    }
}
