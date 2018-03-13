using System;

namespace TicTacToeMain
{
    public class GamePlay
    {
        public Tuple<int, int> ValidateLocation(Board board, Tuple<int,int> userMove)
        {
            while (board.IsLocationTaken(userMove))
            {
                Console.WriteLine("This location is taken");
                GetUserInput.PrintInstructions();
                userMove = GetUserInput.UserInput();
            }

            return userMove;
        }
    }
}