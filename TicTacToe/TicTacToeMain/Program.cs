using System;

namespace TicTacToeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            DisplayBoard seeBoard = new DisplayBoard(board);
            
            int amountOfMoves = 0;
            while (amountOfMoves <= 4)
            {
                GetUserInput move = new GetUserInput();
                move.PrintInstructions();
                var userMove = move.UserInput();
                if (!userMove.Equals(Tuple.Create(-1,-1)))
                {
                    while (board.IsLocationTaken(userMove))
                    {
                        Console.WriteLine("This location is taken");
                        move.PrintInstructions();
                        userMove = move.UserInput();
                    }


                    amountOfMoves += 1;
                    board.AddMove(userMove);
                    seeBoard.PrintBoard(board);
                    ComputerTurn compMove = new ComputerTurn(board);
                    board.AddMove(compMove.FindAvailableSpace(), true);
                    seeBoard.PrintBoard(board);
                }
                else
                {
                    amountOfMoves = 10;
                }
            }

        }
    }
}