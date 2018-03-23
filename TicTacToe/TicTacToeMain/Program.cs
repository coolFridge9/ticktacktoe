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
            var didUserWin = false;
            var didComputerWin = false;

            while (GamePlay.CanKeepPlaying(board.HasEmptySpaces() , didComputerWin))
            {

                var userMove = GamePlay.GetMove(); 
                
                if (board.DidUserQuit(userMove))
                    break;
                
                
                userMove = GamePlay.ValidateLocationNotTaken(board, userMove); 
                
                if (board.DidUserQuit(userMove))
                    break;
                
                board.AddMove(userMove);
                didUserWin = board.DidUserWin();
                DisplayBoard.PrintBoard(board);
                
                if (GamePlay.IsBoardFull(board) || didUserWin)
                    break;
                
                var computerMove = new ComputerMoves();
                board.AddMove(computerMove.MoveToBlockOpponent(board), true);
                didComputerWin =board.DidComputerWin();
                DisplayBoard.PrintBoard(board);
                
                 
            }

            var endGame = new FinishGameMessage(didUserWin, didComputerWin);


        }
    }
}