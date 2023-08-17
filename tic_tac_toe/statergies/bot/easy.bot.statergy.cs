using contract;
using enums;

namespace satergies.bot
{
    public class EasyBot : IBotStatergy
    {
        public (int row, int col) GetMove(IBoard board)
        {
            foreach (var row in board.GetBoardLayout())
            {
                foreach (var cell in row)
                {
                    if (cell.GetStatus() == enums.CellStatus.EMPTY)
                    {
                        return (row: cell.GetRow(), col: cell.GetCol());
                    }
                }
            }

            return (-1, -1);
        }
    }
}