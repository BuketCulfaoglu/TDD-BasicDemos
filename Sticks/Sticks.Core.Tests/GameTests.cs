namespace Sticks.Core.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Ctor_LessThen10Sticks_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Game(9, Player.Machine));
        }

        [Test]
        public void Ctor_ValidParams_GameIsInCorrectState()
        {
            int sticks = 10;
            Player player = Player.Machine;

            var sut = new Game(sticks, player);

            Assert.That(sut.NumberOfSticks, Is.EqualTo(sticks));
            Assert.That(sut.Turn, Is.EqualTo(player));
        }

        [Test]
        [TestCase(0)]
        [TestCase(4)]
        public void HumanMakesMove_InvalidNumberOfSticks_Throws(int take)
        {
            var sut = new Game(10, Player.Human);

            Assert.Throws<ArgumentException>(() => sut.HumanMakesMove(take));
        }
    }


}