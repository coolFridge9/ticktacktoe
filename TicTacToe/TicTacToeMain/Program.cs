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

            while (GamePlay.CanKeepPlaying(board.IsAvailableBoardSpace() , compWin))
            {

                var userMove = GamePlay.GetMove(); 
                
                if (board.DidUserQuit(userMove))
                    break;
                
                userMove = GamePlay.ValidateLocation(board, userMove);
                board.AddMove(userMove);
                userWin = board.DidUserWin();
                DisplayBoard.PrintBoard(board);
                
                if (ComputerTurn.IsBoardFull(board) || userWin)
                    break;
                
                board.AddMove(ComputerTurn.FindAvailableSpace(board), true);
                compWin =board.DidComputerWin();
                DisplayBoard.PrintBoard(board);
                
                 
            }

            var endGame = new FinishGameMessage(userWin, compWin);


        }
    }
}