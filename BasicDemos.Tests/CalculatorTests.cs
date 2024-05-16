namespace BasicDemos.Tests
{
    [TestFixture]
    public class CalculatorTests
    {

        [Test]
        public void Add_WhenCalled_ReturnsSum()
        {
            var calculator = new Calculator();

            int result = calculator.Add(3, 4);

            Assert.AreEqual(7, result);
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsDifference()
        {
            var calculator = new Calculator();

            int result = calculator.Subtract(7, 4);

            Assert.AreEqual(3, result);
        }


        [Test]
        public void Multiply_WhenCalled_ReturnsProduct()
        {
            var calculator = new Calculator();

            int result = calculator.Multiply(3, 4);

            Assert.AreEqual(12, result);
        }


        [Test]
        public void Divide_WhenCalled_ReturnsQuotient()
        {
            var calculator = new Calculator();

            int result = calculator.Divide(12, 3);

            Assert.AreEqual(4, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsArgumentException()
        {
            var calculator = new Calculator();

            Assert.Throws<ArgumentException>(() => calculator.Divide(10, 0));
        }

    }
}