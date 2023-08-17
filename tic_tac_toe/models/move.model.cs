using contract;

namespace models
{

    public class Move : IMove
    {
        private readonly IUser PlayerObj;
        private readonly ICell Cell;
        public Move(ICell cell, IUser player)
        {
            this.PlayerObj = player;
            this.Cell = cell;
        }
        public ICell GetCell()
        {
            return Cell;
        }
        public IUser GetPlayer()
        {
            return PlayerObj;
        }

    }
}