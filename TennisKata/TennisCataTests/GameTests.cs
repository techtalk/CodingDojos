using Xunit;

namespace TennisCataTests
{
    public class GameTests
    {
        [Fact]
        public void Game_Initialize_Score00()
        {
            var game = CreateNewGame();

            Assert.Equal("0-0", game.Score);
        }

        [Fact]
        public void Player2Scores_NewGame_Score015()
        {
            var game = CreateNewGame();

            game.Player2Scores();

            Assert.Equal("Love-15", game.Score);
        }

        [Fact]
        public void Player1Scores_NewGame_Score150()
        {
            var game = CreateNewGame();

            game.Player1Scores();

            Assert.Equal("15-Love", game.Score);
        }

        [Fact]
        public void Player1ScoresPlayer2Scores_NewGame_Score1515()
        {
            var game = CreateNewGame();

            game.Player1Scores();
            game.Player2Scores();

            Assert.Equal("15-15", game.Score);
        }

        [Fact]
        public void Player1Scores_DeuceGame_ScoreAdvantagePlayer1()
        {
            var game = CreateNewGame(new DeuceState());

            game.Player1Scores();

            Assert.Equal("Advantage Player 1", game.Score);
        }

        [Fact]
        public void Player2Scores_AdvantagePlayer1Game_ScoreDeuce()
        {
            var game = CreateNewGame(new AdvantagePlayerOneState());

            game.Player2Scores();

            Assert.Equal("Deuce", game.Score);
        }

        [Fact]
        public void Player1Scores_AdvantagePlayer1Game_ScoreGamePlayer1()
        {
            var game = CreateNewGame(new AdvantagePlayerOneState());

            game.Player1Scores();

            Assert.Equal("Game Player 1", game.Score);
        }

        private static Game CreateNewGame(IGameState state = null)
        {
            return state == null ? new Game() : new Game(state);
        }
    }

    
}