using contract;

namespace models
{
    public class Player : User
    {
        public Player(string name, ISymbol symbol) : base(name, symbol)
        {

        }
        public override (int row, int col) GetNextMove(IBoard board)
        {
            Console.Write("enter row number");
            var rowStr = Console.ReadLine();
            Console.Write("enter col number");
            var colStr = Console.ReadLine();
            int rowData = -1;
            int colData = -1;
            if (!int.TryParse(rowStr, out rowData))
            {
                Console.WriteLine("invalid row number");
            }
            else if (!int.TryParse(colStr, out colData))
            {
                Console.WriteLine("invalid col number");
            }
            Console.WriteLine("row: {0}, col: {1}", rowData, colData);
            return (row: rowData, col: colData);
        }
    }
}