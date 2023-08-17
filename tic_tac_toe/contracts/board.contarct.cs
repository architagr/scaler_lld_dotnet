namespace contract
{
    public interface IBoard
    {
        List<List<ICell>> GetBoardLayout();
        int GetBoardSize();
        void Print();
    }
}