using System;

namespace TicTacToeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var seeBoard = new DisplayBoard(board);
            var computer = new ComputerTurn();
            var userWin = false;
            var compWin = false;
            
            while (board.SpacesTaken < 9 && !userWin && !compWin)
            {
                var move = new GetUserInput();
                GetUserInput.PrintInstructions();
                var userMove = GetUserInput.UserInput();
                if (!userMove.Equals(Tuple.Create(-1,-1)))
                {
                    while (board.IsLocationTaken(userMove))
                    {
                        Console.WriteLine("This location is taken");
                        GetUserInput.PrintInstructions();
                        userMove = GetUserInput.UserInput();
                    }

                    board.AddMove(userMove);
                    userWin = board.DidUserWin();
                    DisplayBoard.PrintBoard(board);
                    if (!ComputerTurn.IsBoardFull(board) && !userWin)
                    {
                        board.AddMove(ComputerTurn.FindAvailableSpace(board), true);
                        compWin =board.DidComputerWin();
                    }

                    DisplayBoard.PrintBoard(board);
                }
              
            }
            if(userWin)
                Console.WriteLine("Congradulations! you are the ultimate winner");
            else if(compWin)
                Console.WriteLine("I cant believe you lost smh");
            else
            {
                Console.WriteLine("Looks like no party won the game\nimprove your game next time");
            }
            

        }
    }
}