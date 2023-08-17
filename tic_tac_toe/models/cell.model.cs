using contract;
using enums;

namespace models
{
    public class Cell : ICell
    {
        private readonly int Row;
        private readonly int Col;
        private IUser? Player;
        private CellStatus Status = CellStatus.EMPTY;

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public int GetCol()
        {
            return Col;
        }

        public IUser? GetPlayer()
        {
            return Player;
        }

        public int GetRow()
        {
            return Row;
        }

        public CellStatus GetStatus()
        {
            return Status;
        }

        public string Print()
        {
            if (Status == CellStatus.EMPTY)
            {
                return " ";
            }
            else if (Status == CellStatus.FILLED && Player is not null)
            {
                return Player.GetSymbol().GetSymbolChar().ToString();
            }
            return "-";
        }

        public void SetStatus(CellStatus status)
        {
            Status = status;
        }

        public void SetPlayer(IUser player)
        {
            Player = player;
        }

    }
}