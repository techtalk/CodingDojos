using System.Text;

namespace GameOfLife;

public class Game
{
    public List<string> Board { get; }

    public Game(List<string> board)
    {
        Board = board;
    }

    //maybe count and print generation as well?
    public string NextGeneration()
    {
        return GetPrintableBoard(Board);
    }

    private string GetPrintableBoard(List<string> board)
    {
        var stringBuilder = new StringBuilder();
        foreach (var row in board)
            stringBuilder.AppendLine(row);
        
        return stringBuilder.ToString();
    }
}