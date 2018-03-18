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
                if (userMove.Equals(Board.QuitMove))
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
        
        public static bool IsBoardFull(Board board)
        {
            return board.SpacesTaken == Board.SizeOfboard * Board.SizeOfboard;
        }
    }
}