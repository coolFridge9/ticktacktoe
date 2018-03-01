using System;

namespace TicTacToeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board()
            GetUserInput move = new GetUserInput();
            move.PrintInstructions();
            var userMove = move.UserInput();
            
        }
    }
}