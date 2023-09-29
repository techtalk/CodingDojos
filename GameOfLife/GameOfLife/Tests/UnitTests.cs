using GameOfLife;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //could we somehow use a regular string here?
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

        //what are Edge cases we could test?
    }
}