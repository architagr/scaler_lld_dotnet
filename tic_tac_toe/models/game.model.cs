using contract;
using enums;

namespace models
{
    public class Game
    {
        public IBoard Board { get; private set; }
        private readonly List<IUser> Players;
        private readonly List<IWinningStatergy> WinningStatergies;
        public GameStatus GameState { get; private set; }
        private List<IMove> Moves = new List<IMove>();
        private int CurrentPlayer = 0;
        public IUser? Winner { get; private set; }

        public Game(int boardSize, List<IUser> players, List<IWinningStatergy> winningStatergies)
        {
            Board = new Board(boardSize);
            this.Players = players;
            this.WinningStatergies = winningStatergies;
            this.GameState = GameStatus.INPROGRESS;

        }
        public void PrintBoard()
        {
            Board.Print();
        }
        public void MakeMove()
        {
            Console.WriteLine("Chance for {0}", Players[CurrentPlayer].GetName());
            (int row, int col) = Players[CurrentPlayer].GetNextMove(Board);
            ICell proposedCell = new Cell(row, col);
            if (!ValidateMove(proposedCell))
            {
                Console.WriteLine("Invalid Move");
                return;
            }
            ICell currentCell = Board.GetBoardLayout()[row][col];
            currentCell.SetStatus(CellStatus.FILLED);
            currentCell.SetPlayer(Players[CurrentPlayer]);
            IMove move = new Move(currentCell, Players[CurrentPlayer]);
            Moves.Add(move);
            if (CheckWinner(move))
            {
                return;
            }
            if (CheckDraw())
            {
                return;
            }
            CurrentPlayer = (CurrentPlayer + 1) % Players.Count;
        }
        public void PrintResult()
        {
            if (GameState == GameStatus.DRAW)
            {
                Console.WriteLine("it is Draw");
            }
            Console.WriteLine("Player {0} won", Winner.GetName());

        }
        private bool CheckWinner(IMove move)
        {
            foreach (IWinningStatergy statergy in WinningStatergies)
            {
                if (statergy.CheckWinner(Board, move))
                {
                    Winner = Players[CurrentPlayer];
                    GameState = GameStatus.END;
                    return true;
                }
            }
            return false;
        }
        private bool CheckDraw()
        {
            if (Moves.Count == Board.GetBoardSize() * Board.GetBoardSize())
            {
                GameState = GameStatus.DRAW;
                return true;
            }
            return false;
        }
        private bool ValidateMove(ICell cell)
        {
            int row = cell.GetRow();
            int col = cell.GetCol();
            if (row < 0 || col < 0 || row >= Board.GetBoardSize() || col >= Board.GetBoardSize())
            {
                return false;
            }
            return Board.GetBoardLayout()[row][col].GetStatus() == CellStatus.EMPTY;
        }
    }
}