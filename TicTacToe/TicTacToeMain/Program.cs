using System;

namespace TicTacToeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayBoard seeBoard = new DisplayBoard();
            Board board = new Board();
            GetUserInput move = new GetUserInput();
            move.PrintInstructions();
            var userMove = move.UserInput();
            while (board.IsLocationTaken(userMove))
            {
                Console.WriteLine("This location is taken");
                userMove = move.UserInput();
            }
            board.AddMove(userMove,false);
            seeBoard.PrintBoard(board);
            ComputerTurn compMove = new ComputerTurn(board);
            seeBoard.PrintBoard(board);
            
        }
    }
}