
using contract;

namespace satergies.winning
{
    public class ColWinngingStatergy : IWinningStatergy
    {
        private readonly List<Dictionary<ISymbol, int>> ColDataMap;
        public ColWinngingStatergy(IList<IUser> players, int boardSize)
        {
            ColDataMap = new List<Dictionary<ISymbol, int>>();
            for (int i = 0; i < boardSize; i++)
            {
                Dictionary<ISymbol, int> dataMap = new Dictionary<ISymbol, int>();
                for (int j = 0; j < players.Count; j++)
                {
                    dataMap.Add(players[j].GetSymbol(), 0);
                }
                ColDataMap.Add(dataMap);
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
            var count = ColDataMap[move.GetCell().GetCol()][move.GetPlayer().GetSymbol()];
            count += incrementCount;
            if (count < 0)
            {
                count = 0;
            }
            ColDataMap[move.GetCell().GetCol()][move.GetPlayer().GetSymbol()] = count;
            return count;
        }
    }
}