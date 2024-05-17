namespace BasicDemos.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [TearDown]
        public void TearDown()
        {
            _calculator.Dispose();
        }

        [Test]
        public void Add_WhenCalled_ReturnsSum()
        {
            const int expected = 7;
            int actual = _calculator.Add(3, 4);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsDifference()
        {
            const int expected = 3;
            int actual = _calculator.Subtract(7, 4);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiply_WhenCalled_ReturnsProduct()
        {
            const int expected = 12;
            int actual = _calculator.Multiply(3, 4);

            Assert.That(actual, Is.EqualTo(expected));
            //Assert.AreEqual(12, actual);
        }

        [Test]
        public void Divide_WhenCalled_ReturnsQuotient()
        {
            const int expected = 4;
            int actual = _calculator.Divide(12, 3);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Divide_ByZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _calculator.Divide(10, 0));
        }
    }
}