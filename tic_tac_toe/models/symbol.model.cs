using contract;

namespace models
{

    public class Symbol : ISymbol
    {
        private readonly char Icon;
        public Symbol(char icon)
        {
            this.Icon = icon;
        }
        public char GetSymbolChar()
        {
            return Icon;
        }
    }
}