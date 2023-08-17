using contract;

namespace models
{
    public class Bot : User
    {

        private readonly IBotStatergy MoveStatergy;

        public Bot(string name, ISymbol symbol, IBotStatergy moveStatergy) : base(name, symbol)
        {
            MoveStatergy = moveStatergy;
        }
        public override (int row, int col) GetNextMove(IBoard board)
        {
            return MoveStatergy.GetMove(board);
        }
    }
}