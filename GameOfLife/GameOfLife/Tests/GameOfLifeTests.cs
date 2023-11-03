using GameOfLife;

namespace Tests
{
    [TestClass]
    public class GameOfLifeTests : VerifyBase
    {
        [TestMethod]
        public async Task NewLife()
        {
            var board = new List<string>
            {
                "........",
                "....*...",
                "...**...",
                "........",
                "........",
                "........",
                "........",
                "........"
            };

            var game = new Game(board);
            var nextGen = game.NextGeneration();

            await Verify(nextGen);
        }

        [TestMethod]
        public async Task OvercrowdedCellDies()
        {
            var board = new List<string>
            {
                "........",
                "....*...",
                "...***..",
                "....*...",
                "........",
                "........",
                "........",
                "........"
            };

            var game = new Game(board);
            var nextGen = game.NextGeneration();

            await Verify(nextGen);
        }

        [TestMethod]
        public async Task SubsequentCallsToNextGenerationWorkWithThePreviousState()
        {
            var board = new List<string>
            {
                "........",
                "....*...",
                "...***..",
                "....*...",
                "........",
                "........",
                "........",
                "........"
            };

            var game = new Game(board);
            game.NextGeneration();
            var nextGen = game.NextGeneration();

            await Verify(nextGen);
        }

        [TestMethod]
        public async Task ThereIsNoLifeOutOfBounds()
        {
            var board = new List<string>
            {
                "**....**",
                "*......*",
                "........",
                "........",
                "........",
                "........",
                "*......*",
                "**....**"
            };

            var game = new Game(board);
            var nextGen = game.NextGeneration();

            await Verify(nextGen);
        }
        
        [TestMethod]
        public async Task FiveRounds()
        {
            var board = new List<string>
            {
                "........",
                "....*...",
                "...***..",
                "....*...",
                "........",
                "........",
                "........",
                "........"
            };

            var game = new Game(board);
            var nextGen = string.Empty;

            for (var i = 0; i < 5; i++)
            {
                nextGen = game.NextGeneration();
            }

            await Verify(nextGen);
        }

        //schreibe mir einen test mit einen board welches 4 mal4 großes board hat
        //mit 4 lebenden zellen
        //und nach 4 generationen soll das board leer sein
        [TestMethod]
        public async Task FourRounds()
        {
            var board = new List<string>
            {
                "....",
                ".*..",
                "..*.",
                "...."
            };

            var game = new Game(board);
            var nextGen = string.Empty;

            for (var i = 0; i < 4; i++)
            {
                nextGen = game.NextGeneration();
            }

            await Verify(nextGen);
        }

        //schreibe mir einen test mit einen board welches ein triangle aus 16 x16 toten zellen hat
        //und nach 4 generationen soll das board leer sein
        [TestMethod]
        public async Task FourRoundsTriangle()
        {
            var board = new List<string>
            {
                "................",
                "............*...",
                "...........*.*..",
                "..........*...*.",
                ".........*.....*",
                "........*.......",
                ".......*........",
                "......*.........",
                ".....*..........",
                "....*...........",
                "...*............",
                "..*.............",
                ".*..............",
                "*...............",
                "................",
                "................"
            };

            var game = new Game(board);
            var nextGen = string.Empty;

            for (var i = 0; i < 4; i++)
            {
                nextGen = game.NextGeneration();
            }

            await Verify(nextGen);
        }

        //schreibe manuels test
        [TestMethod]
        public async Task ManuelTest()
        {
            var board = new List<string>
            {
                ".",
                "..",
                "...",
                "....",
                "...*.",
                "...**."
            };

            var game = new Game(board);
            var nextGen = game.NextGeneration();

            await Verify(nextGen);
        }

        //schreibe mir drei test wie manueltest
        [TestMethod]
        public async Task ManuelTest2()
        {
            var board = new List<string>
            {
                "........",
                "....*...",
                "...**...",
                "........",
                "........",
                "........",
                "........",
                "........"
            };

            var game = new Game(board);
            var nextGen = game.NextGeneration();

            await Verify(nextGen);
        }
 




    }
}