namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void TestFizzBuzz()
        {
            Assert.That(FizzBuzz(0), Is.EqualTo("0"));
            Assert.That(FizzBuzz(3), Is.EqualTo("Fizz"));
            Assert.That(FizzBuzz(5), Is.EqualTo("Buzz"));
            Assert.That(FizzBuzz(7), Is.EqualTo("7"));
            Assert.That(FizzBuzz(15), Is.EqualTo("FizzBuzz"));
        }

        private string FizzBuzz(int i)
        {
            if (i == 0) return i.ToString();
            if (i % 15 == 0)
                return "FizzBuzz";
            if (i % 3 == 0)
                return "Fizz";
            if (i % 5 == 0)
                return "Buzz";
            return i.ToString();
        }
    }
}