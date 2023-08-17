using System;
using enums;
using contract;
using models;
using satergies.bot;
using satergies.winning;
namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            List<IUser> players = new List<IUser>
            {
                new Player("Archit", new Symbol('X')),
                new Bot("Archit Bot", new Symbol('O'), new EasyBot())
            };

            List<IWinningStatergy> winningStatergies = new List<IWinningStatergy>
            {
                new RowWinngingStatergy(players, 3),
                new ColWinngingStatergy(players, 3)
            };

            Game g = new Game(3, players, winningStatergies);
            g.PrintBoard();

            while (g.GameState == GameStatus.INPROGRESS)
            {
                // todo: undo code
                g.MakeMove();
                g.PrintBoard();
            }
            g.PrintResult();
        }
    }

}