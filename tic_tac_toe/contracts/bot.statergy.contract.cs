namespace contract
{
    public interface IBotStatergy
    {
        (int row, int col) GetMove(IBoard board);
    }
}