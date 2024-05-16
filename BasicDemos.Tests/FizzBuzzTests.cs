namespace BasicDemos.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void TestFizzBuzz()
        {
            Assert.That(FizzBuzz.GetFizzBuzzText(0), Is.EqualTo("0"));
            Assert.That(FizzBuzz.GetFizzBuzzText(3), Is.EqualTo("Fizz"));
            Assert.That(FizzBuzz.GetFizzBuzzText(5), Is.EqualTo("Buzz"));
            Assert.That(FizzBuzz.GetFizzBuzzText(7), Is.EqualTo("7"));
            Assert.That(FizzBuzz.GetFizzBuzzText(15), Is.EqualTo("FizzBuzz"));
        }

    }
}