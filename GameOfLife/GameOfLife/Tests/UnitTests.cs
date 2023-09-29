using GameOfLife;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //we could somehow use a verbatim string here..
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
            string nextGen = game.NextGeneration();

            //can we make this easier to read and write?
            var expected = "........\r\n...**...\r\n...**...\r\n........\r\n........\r\n........\r\n........\r\n........\r\n";
            Assert.AreEqual(expected, nextGen);
        }
    }
}