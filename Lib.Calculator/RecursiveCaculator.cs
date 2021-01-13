using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Calculator
{
    public class RecursiveCaculator : ICalculator
    {
        private List<List<long>> mResults;

        public List<List<long>> Solve(long goal, long[] elements)
        {

            mResults = new List<List<long>>();
            RecursiveSolve(goal, 0,
                new List<long>(), new List<long>(elements), 0);
            return mResults;
        }

        private void RecursiveSolve(long goal, long currentSum,
            List<long> included, List<long> notIncluded, int startIndex)
        {

            for (int index = startIndex; index < notIncluded.Count; index++)
            {

                long nextValue = notIncluded[index];
                if (currentSum + nextValue == goal)
                {
                    List<long> newResult = new List<long>(included);
                    newResult.Add(nextValue);
                    mResults.Add(newResult);
                }
                else if (currentSum + nextValue < goal)
                {
                    List<long> nextIncluded = new List<long>(included);
                    nextIncluded.Add(nextValue);
                    List<long> nextNotIncluded = new List<long>(notIncluded);
                    nextNotIncluded.Remove(nextValue);
                    RecursiveSolve(goal, currentSum + nextValue,
                        nextIncluded, nextNotIncluded, startIndex++);
                }
            }
        }

        public IEnumerable<List<long>> Calculate(List<long> nums, long sum)
        {
            mResults = new List<List<long>>();
            RecursiveSolve(sum, 0,
                new List<long>(), new List<long>(nums), 0);
            return mResults;
        }
    }
}
