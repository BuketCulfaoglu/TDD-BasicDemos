namespace Sticks.Core.Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Ctor_LessThen10Sticks_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Game(Player.Machine, 9));
        }

        [Test]
        public void Ctor_ValidParams_GameIsInCorrectState()
        {
            int sticks = 10;
            Player player = Player.Machine;

            var sut = new Game(player, sticks);

            Assert.That(sut.NumberOfSticks, Is.EqualTo(sticks));
            Assert.That(sut.Turn, Is.EqualTo(player));
        }

        [Test]
        [TestCase(0)]
        [TestCase(4)]
        public void HumanMakesMove_InvalidNumberOfSticks_Throws(int take)
        {
            var sut = new Game(Player.Human, 10);

            Assert.Throws<ArgumentException>(() => sut.HumanMakesMove(take));
        }

        [Test]
        public void HumanMakesMove_TurnOfMachine_Throws()
        {
            var sut = new Game(Player.Machine, 10);

            Assert.Throws<InvalidOperationException>(() => sut.HumanMakesMove(1));
        }

        [Test]
        [TestCase(1, 9)]
        [TestCase(2, 8)]
        [TestCase(3, 7)]
        public void HumanMakesMove_CorrectGameState(int takes, int remains)
        {
            var sut = new Game(Player.Human, 10);
            sut = sut.HumanMakesMove(takes);

            Assert.That(sut.NumberOfSticks, Is.EqualTo(remains));
            Assert.That(sut.Turn, Is.EqualTo(Player.Machine));
        }
    }
}