namespace contract
{
    public interface IUser
    {
        string GetName();
        ISymbol GetSymbol();
        (int row, int col) GetNextMove(IBoard board);
    }
}