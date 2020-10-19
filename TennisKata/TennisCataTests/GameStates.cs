using System;

namespace TennisCataTests
{
    public interface IGameState
    {
        IGameState Player1Scores();
        IGameState Player2Scores();
        string Score { get; }
    }

    class InitialState : IGameState
    {
        public string Score => "0-0";

        public IGameState Player1Scores()
        {
            return new Player1FifteenPlayer2LoveState();
        }

        public IGameState Player2Scores()
        {
            return new Player1LovePlayer2Fifteen();
        }
    }

    class Player1FifteenPlayer2LoveState : IGameState
    {
        public string Score => "15-Love";

        public IGameState Player1Scores()
        {
            return null;
        }

        public IGameState Player2Scores()
        {
            return new FifteenFifteenState();
        }
    }

    class Player1LovePlayer2Fifteen : IGameState
    {
        public string Score => "Love-15";

        public IGameState Player1Scores()
        {
            return new FifteenFifteenState();
        }

        public IGameState Player2Scores()
        {
            return null;
        }
    }

    class FifteenFifteenState : IGameState
    {
        public string Score => "15-15";

        public IGameState Player1Scores()
        {
            return null;
        }

        public IGameState Player2Scores()
        {
            return null;
        }
    }

    class DeuceState : IGameState
    {
        public IGameState Player1Scores()
        {
            return new AdvantagePlayerOneState();
        }

        public IGameState Player2Scores()
        {
            throw new NotImplementedException();
        }

        public string Score => "Deuce";
    }

    internal class AdvantagePlayerOneState : IGameState
    {
        public IGameState Player1Scores()
        {
            return new GamePlayerOneState();
        }

        public IGameState Player2Scores()
        {
            return new DeuceState();
        }

        public string Score => "Advantage Player 1";
    }

    internal class GamePlayerOneState : IGameState
    {
        public IGameState Player1Scores()
        {
            return this;
        }

        public IGameState Player2Scores()
        {
            return this;
        }

        public string Score => "Game Player 1";
    }
}