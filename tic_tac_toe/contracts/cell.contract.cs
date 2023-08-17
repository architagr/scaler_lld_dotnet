using enums;

namespace contract
{
    public interface ICell
    {
        int GetCol();
        int GetRow();
        CellStatus GetStatus();
        IUser? GetPlayer();
        string Print();
        void SetStatus(CellStatus status);
        void SetPlayer(IUser player);
    }
}