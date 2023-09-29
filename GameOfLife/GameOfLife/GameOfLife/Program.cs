//https://codingdojo.org/kata/GameOfLife/

using GameOfLife;

Console.WriteLine("Input a Board with . (dead cell) and * (alive cell).");
Console.WriteLine("End you Input with an x");
List<string> board = new();

do
{
    board.Add(Console.ReadLine()!);
}
while(board.Last() != "x");

board.RemoveAt(board.Count - 1);

var game = new Game(board);
while (true)
{
    var newBoard = game.NextGeneration();
    Console.WriteLine(newBoard);
    Console.ReadKey();
    Console.WriteLine();
}