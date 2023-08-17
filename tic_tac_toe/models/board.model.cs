using contract;

namespace models
{
    public class Board : IBoard
    {
        public readonly int BoardSize;
        public readonly List<List<ICell>> BoardLayout;

        public Board(int boardSize)
        {
            BoardSize = boardSize;
            BoardLayout = new List<List<ICell>>();
            for (int i = 0; i < boardSize; i++)
            {
                var row = new List<ICell>();
                for (int j = 0; j < boardSize; j++)
                {
                    row.Add(new Cell(i, j));
                }
                BoardLayout.Add(row);
            }

        }
        public List<List<ICell>> GetBoardLayout()
        {
            return BoardLayout;
        }

        public int GetBoardSize()
        {
            return BoardSize;
        }

        public void Print()
        {
            foreach (var row in BoardLayout)
            {
                Console.Write("|");
                foreach (var cell in row)
                {
                    Console.Write("{0} |", cell.Print());
                }
                Console.Write("\n");
            }
        }
    }
}