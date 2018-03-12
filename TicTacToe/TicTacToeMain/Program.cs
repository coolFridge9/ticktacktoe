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
            var quit = false;
            
            while (board.IsAvailableBoardSpace() && !userWin && !compWin && !quit)
            {
                var move = new GetUserInput();
                GetUserInput.PrintInstructions();
                var userMove = GetUserInput.UserInput();
                quit = userMove.Equals(Tuple.Create(-1, -1));
                if (!quit)
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
                        DisplayBoard.PrintBoard(board);
                    }

                    
                }
                
              
            }

            var endGame = new FinishGameMessage(userWin, compWin);


        }
    }
}