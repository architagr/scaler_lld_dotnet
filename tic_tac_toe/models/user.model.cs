using contract;

namespace models
{

    public abstract class User : IUser
    {
        private readonly string Name;
        private readonly ISymbol SymbolObj;

        public User(string name, ISymbol symbolObj)
        {
            this.Name = name;
            this.SymbolObj = symbolObj;
        }
        public string GetName()
        {
            return Name;
        }

        public ISymbol GetSymbol()
        {
            return SymbolObj;
        }
        public abstract (int row, int col) GetNextMove(IBoard board);
    }


}