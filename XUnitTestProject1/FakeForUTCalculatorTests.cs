using Lib.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject1
{
    public class FakeForUTCalculatorTests
    {
        //ICalculator fake = new FakeForUTCalculator();
        ICalculator fake = new RecursiveCaculator();

        private bool AreTwoArrayEqual(List<long> expected, List<long> actual)
        {
            return Enumerable.SequenceEqual(expected.OrderBy(t => t), actual.OrderBy(t => t));
        }
        private void AssertAreTwoArrayEqual(List<long> expected, List<long> actual)
        {
            Assert.True(AreTwoArrayEqual(expected, actual));
        }

        private void AssertResultContainsArray(List<long> expected, IEnumerable<List<long>> actual)
        {
            Assert.Contains(actual, a => AreTwoArrayEqual(expected, a));
        }

        private void AssertResultNotContainsArray(List<long> expected, IEnumerable<List<long>> actual)
        {
            Assert.DoesNotContain(actual, a => AreTwoArrayEqual(expected, a));
        }

        [Fact]
        public void EqualTest()
        {
            var lst1 = new List<long>() { 1, 2 };
            var lst2 = new List<long>() { 2, 1 };
            AssertAreTwoArrayEqual(lst1, lst2);
        }

        [Fact]
        public void Test1()
        {
            var nums = new List<long>() { 2, 3, 5 };
            var expected = new List<long>() { 2 };
            long sum = 2;
            AssertResultContainsArray(expected, fake.Calculate(nums, sum));
            AssertResultNotContainsArray(new List<long>() { 3 }, fake.Calculate(nums, sum));
            AssertResultNotContainsArray(new List<long>() { 5 }, fake.Calculate(nums, sum));
        }

        [Fact]
        public void Test2()
        {
            var nums = new List<long>() { 2, 3, 5 };
            var expected1 = new List<long>() { 5 };
            var expected2 = new List<long>() { 2, 3 };
            long sum = 5;
            AssertResultContainsArray(expected1, fake.Calculate(nums, sum));
            AssertResultContainsArray(expected2, fake.Calculate(nums, sum));
        }

        [Fact]
        public void Test3()
        {
            var nums = new List<long>() { 2, 3, 5 };
            var expected1 = new List<long>() { 2, 3, 5 };
            long sum = 10;
            AssertResultContainsArray(expected1, fake.Calculate(nums, sum));
        }

    }
}
