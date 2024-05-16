namespace BasicDemos.Tests
{
    [TestFixture]
    public class RomanTests
    {

        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(2024, "MMXXIV")]
        public void TestRomanNumeral(int expected, string roman)
        {
            Assert.AreEqual(expected, Roman.Parse(roman));
        }
    }
}