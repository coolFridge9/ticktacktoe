using System;

namespace TicTacToeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var seeBoard = new DisplayBoard(board);
            var gamePlay= new GamePlay();
            var userWin = false;
            var compWin = false;
            var quit = false;
            
            while (board.IsAvailableBoardSpace() && !userWin && !compWin && !quit)
            {
                var move = new GetUserInput();
                GetUserInput.PrintInstructions();
                var userMove = GetUserInput.UserInput();
                quit = board.DidUserQuit(userMove);
                if (!quit)
                {
                    userMove = gamePlay.ValidateLocation(board, userMove);
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