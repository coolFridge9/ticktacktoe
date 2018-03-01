using System;

namespace TicTacToeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            GetUserInput move = new GetUserInput();
            move.PrintInstructions();
            Console.WriteLine(move.UserInput());
            
        }
    }
}