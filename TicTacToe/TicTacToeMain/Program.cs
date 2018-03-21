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
                
                if (Board.DidUserQuit(userMove))
                    break;
                
                
                userMove = GamePlay.ValidateLocationNotTaken(board, userMove); 
                
                if (Board.DidUserQuit(userMove))
                    break;
                
                board.AddMove(userMove);
                userWin = Board.DidUserWin();
                DisplayBoard.PrintBoard(board);
                
                if (GamePlay.IsBoardFull(board) || userWin)
                    break;
                
                board.AddMove(ComputerMoves.FindRandomSpace(board), true);
                compWin =board.DidComputerWin();
                DisplayBoard.PrintBoard(board);
                
                 
            }

            var endGame = new FinishGameMessage(userWin, compWin);


        }
    }
}