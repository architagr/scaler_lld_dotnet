using contract;

namespace contract
{
    public interface IWinningStatergy
    {
        bool CheckWinner(IBoard board, IMove move);
        void Undo(IBoard board, IMove move);
    }
}