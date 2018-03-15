using System;

namespace TicTacToeMain
{
    public class GamePlay
    {
        public static Tuple<int, int> ValidateLocationNotTaken(Board board, Tuple<int,int> userMove)
        {
            while (board.IsLocationTaken(userMove))
            {
                Console.WriteLine("This location is taken");
                UserInputHandler.PrintInstructions();
                userMove = UserInputHandler.GetUserInput();
                if (userMove.Equals(Tuple.Create(-1, -1)))
                    return userMove;
            }

            return userMove;
        }

        public static bool CanKeepPlaying(bool isSpace, bool compWin)
        {
            return isSpace && !compWin;
        }

        public static Tuple<int, int> GetMove()
        {
            UserInputHandler.PrintInstructions();
            return UserInputHandler.GetUserInput();
        }
    }
}