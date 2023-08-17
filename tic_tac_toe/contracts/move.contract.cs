namespace contract
{
    public interface IMove
    {
        IUser GetPlayer();
        ICell GetCell();
    }
}