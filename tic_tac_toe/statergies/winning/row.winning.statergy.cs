
using contract;
using models;

namespace satergies.winning
{
    public class RowWinngingStatergy : IWinningStatergy
    {
        private readonly List<Dictionary<ISymbol, int>> RowDataMap;
        public RowWinngingStatergy(IList<IUser> players, int boardSize)
        {
            RowDataMap = new List<Dictionary<ISymbol, int>>();
            for (int i = 0; i < boardSize; i++)
            {
                Dictionary<ISymbol, int> dataMap = new Dictionary<ISymbol, int>();
                for (int j = 0; j < players.Count; j++)
                {
                    dataMap.Add(players[j].GetSymbol(), 0);
                }
                RowDataMap.Add(dataMap);
            }
        }
        public bool CheckWinner(IBoard board, IMove move)
        {
            return UpdateDataMap(move, 1) == board.GetBoardSize();
        }

        public void Undo(IBoard board, IMove move)
        {
            UpdateDataMap(move, -1);
        }

        private int UpdateDataMap(IMove move, int incrementCount)
        {
            var count = RowDataMap[move.GetCell().GetRow()][move.GetPlayer().GetSymbol()];
            count += incrementCount;
            if (count < 0)
            {
                count = 0;
            }
            RowDataMap[move.GetCell().GetRow()][move.GetPlayer().GetSymbol()] = count;
            return count;
        }
    }
}