using Fibonacci;

namespace FibonacciTests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(1,2)]
        [TestCase(2,3)]
        [TestCase(3,4)]
        public void TestFibonacci(int expected, int index)
        {
            Assert.AreEqual(expected, FibonacciNumbers.GetFibonacci(index));
        }

        [Test]
        public void TestFibonacci_Assert()
        {
            Assert.AreEqual(0, FibonacciNumbers.GetFibonacci(0));
            Assert.AreEqual(1, FibonacciNumbers.GetFibonacci(1));
            Assert.AreEqual(1, FibonacciNumbers.GetFibonacci(2));
        }
    }
}