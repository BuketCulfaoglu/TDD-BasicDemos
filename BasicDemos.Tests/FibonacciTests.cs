namespace BasicDemos.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(3, 2)]
        [TestCase(4, 3)]
        public void TestFibonacci(int index, int expected)
        {
            Assert.That(expected, Is.EqualTo(Fibonacci.GetFibonacci(index)));
            //Assert.AreEqual(expected, Fibonacci.GetFibonacci(index));
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        public void TestFibonacci_Assert(int index, int expected)
        {
            Assert.That(expected, Is.EqualTo(Fibonacci.GetFibonacci(index)));
            Assert.That(expected, Is.EqualTo(Fibonacci.GetFibonacci(index)));
            Assert.That(expected, Is.EqualTo(Fibonacci.GetFibonacci(index)));
            //Assert.AreEqual(0, Fibonacci.GetFibonacci(0));
            //Assert.AreEqual(1, Fibonacci.GetFibonacci(1));
            //Assert.AreEqual(1, Fibonacci.GetFibonacci(2));
        }
    }
}