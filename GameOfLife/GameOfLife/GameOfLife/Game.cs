using System.Text;

namespace GameOfLife;

public class Game
{
    private const int UpperLifeBorder = 3;
    private const char LifeCell = '*';
    private const char DeathCell = '.';

    public Game(List<string> board)
    {
        Board = board;
    }

    public List<string> Board { get; private set; }

    //maybe count and print generation as well?
    public string NextGeneration()
    {
        var newBoard = new List<string>();
        
        for (var lineIdx = 0; lineIdx < Board.Count; lineIdx++)
        {
            var line = Board[lineIdx];
            for (var colIdx = 0; colIdx < line.Length; colIdx++)
            {
                var currentCell = line[colIdx];

                var aliveNeighbours = GetAliveNeighbours(lineIdx, colIdx, line);

                if (currentCell == LifeCell)
                    line = CellDies(aliveNeighbours, line, colIdx);
                else
                    line = CellBorn(aliveNeighbours, line, colIdx);
            }

            newBoard.Add(line);
        }

        Board = newBoard;
        return GetPrintableBoard(Board);
    }

    private string CellBorn(int aliveNeighbours, string line, int colIdx)
    {
        
        return aliveNeighbours == UpperLifeBorder ? line.Remove(colIdx, 1).Insert(colIdx, LifeCell.ToString()) : line;
    }

    private string CellDies(int aliveNeighbours, string line, int colIdx)
    {
       
        return aliveNeighbours is < 2 or > UpperLifeBorder ? line.Remove(colIdx, 1).Insert(colIdx, DeathCell.ToString()) : line;
    }

    private int GetAliveNeighbours(int lineIdx, int colIdx, string line)
    {
        var aliveNeighbours = 0;
        //line above
        if (lineIdx > 0)
        {
            if (colIdx > 0 && Board[lineIdx - 1][colIdx - 1] == '*')
                aliveNeighbours++;
            if (Board[lineIdx - 1][colIdx] == '*')
                aliveNeighbours++;
            if (colIdx < line.Length - 1 && Board[lineIdx - 1][colIdx + 1] == '*')
                aliveNeighbours++;
        }

        //same line
        if (colIdx > 0 && Board[lineIdx][colIdx - 1] == '*')
            aliveNeighbours++;
        if (colIdx < line.Length - 1 && Board[lineIdx][colIdx + 1] == '*')
            aliveNeighbours++;

        //line below
        if (lineIdx < Board.Count - 1)
        {
            if (colIdx > 0 && Board[lineIdx + 1][colIdx - 1] == '*')
                aliveNeighbours++;
            if (Board[lineIdx + 1][colIdx] == '*')
                aliveNeighbours++;
            if (colIdx < line.Length - 1 && Board[lineIdx + 1][colIdx + 1] == '*')
                aliveNeighbours++;
        }

        return aliveNeighbours;
    }

    private string GetPrintableBoard(List<string> board)
    {
        var stringBuilder = new StringBuilder();
        foreach (var row in board)
            stringBuilder.AppendLine(row);

        return stringBuilder.ToString();
    }
}