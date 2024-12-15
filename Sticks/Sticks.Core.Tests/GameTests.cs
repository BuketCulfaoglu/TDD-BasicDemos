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

        [Test]
        [TestCase(1, 9)]
        [TestCase(2, 8)]
        [TestCase(3, 7)]
        public void MachineMakesMove_CorrectGameState(int takes, int remains)
        {
            var gen = new PredictableGenerator();
            gen.SetNumber(takes);

            int taken = 0;
            var sut = new Game(Player.Machine, 10, gen);
            sut.MachineMoved += (s, args) => taken = args.Taken;

            sut = sut.MachineMakesMove();

            Assert.That(sut.NumberOfSticks, Is.EqualTo(remains));
            Assert.That(takes, Is.EqualTo(taken));
            Assert.That(sut.Turn, Is.EqualTo(Player.Human));
        }

        [Test]
        [TestCase(1, false)]
        [TestCase(2, true)]
        public void IsGameOver_SomeSticks_ReturnsCorrectResults(int takeWhenTwoSticksInGame, bool isOver)
        {
            var sut = ReduceTo2SticksStartingWithHuman();
            sut = sut.HumanMakesMove(takeWhenTwoSticksInGame);

            bool result = sut.IsGameOver();

            Assert.That(result, Is.EqualTo(isOver));
        }

        private static Game ReduceTo2SticksStartingWithHuman()
        {
            var gen = new PredictableGenerator();
            gen.SetNumber(Game.MinToTake);

            var sut = new Game(Player.Human, 10, gen);
            sut = sut.HumanMakesMove(Game.MaxToTake);   //7
            sut = sut.MachineMakesMove();               //6
            sut = sut.HumanMakesMove(Game.MaxToTake);   //3
            sut = sut.MachineMakesMove();               //2

            return sut;
        }

        [Test]
        public void HumanMakesMove_TakeStickMoreThanInThe_Throws()
        {
            Game sut = ReduceTo2SticksStartingWithHuman();
            Assert.Throws<ArgumentException>(() => sut.HumanMakesMove(Game.MaxToTake));
        }

        [Test]
        public void Ctor_NullGenerator_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Game(Player.Machine, 10, null));
        }
    }
}