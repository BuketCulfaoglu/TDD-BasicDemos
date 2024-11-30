namespace BasicDemos.Tests
{
    [TestFixture]
    public class TicTacToeTests
    {
        [Test]
        public void CreateGame_GameIsInCorrectState()
        {
            Game game = new Game();
            Assert.AreEqual(0, game.MovesCounter);
            Assert.AreEqual(State.Unset, game.GetState(1));
        }

        [Test]
        public void MakeMove_CounterShifts()
        {
            Game game = new Game();
            game.MakeMove(1);

            Assert.AreEqual(1, game.MovesCounter);
        }

        [Test]
        public void MakeInvalidMove_ThrowsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var game = new Game();
                game.MakeMove(0);
            });
        }

        [Test]
        public void MoveOnTheSameSquare_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var game = new Game();
                game.MakeMove(1);
                game.MakeMove(1);
            });
        }

        [Test]
        public void MakingMoves_SetStateCorrectly()
        {
            Game game = new Game();

            MakeMoves(game, 1, 2, 3, 4);

            Assert.AreEqual(State.Cross, game.GetState(1));
            Assert.AreEqual(State.Zero, game.GetState(2));
            Assert.AreEqual(State.Cross, game.GetState(3));
            Assert.AreEqual(State.Zero, game.GetState(4));
        }

        [Test]
        public void GetWinner_ZerosWinVertically_ReturnZeroes()
        {
            Game game = new Game();

            MakeMoves(game, 1, 4, 5, 2, 9);

            Assert.AreEqual(Winner.Crosses, game.GetWinner());
        }

        [Test]
        public void GetWinner_GameIsUnfinished_ReturnsGameIsUnfinished()
        {
            Game game = new Game();

            MakeMoves(game, 1, 2, 4);

            Assert.AreEqual(Winner.GameIsUnfinished, game.GetWinner());
        }

        [Test]
        public void GetWinner_CrossesWinDiagonal_ReturnsCrosses()
        {
            Game game = new Game();

            MakeMoves(game, 1, 2, 3, 5, 7, 8);

            Assert.AreEqual(Winner.Zeroes, game.GetWinner());
        }


        private void MakeMoves(Game game, params int[] indexes)
        {
            foreach (var index in indexes)
            {
                game.MakeMove(index);
            }
        }
    }
}
