namespace TennisCataTests
{
    public class Game
    {
        private IGameState _state = new InitialState();
        public string Score => _state.Score;

        public Game(IGameState state)
        {
            _state = state;
        }

        public Game()
        {
        }

        public void Player1Scores()
        {
            _state = _state.Player1Scores();
        }

        public void Player2Scores()
        {
            _state = _state.Player2Scores();
        }
    }
}