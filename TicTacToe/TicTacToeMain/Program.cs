using System;

namespace TicTacToeMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            DisplayBoard seeBoard = new DisplayBoard(board);
            var computer = new ComputerTurn();
            
            while (board.spacesTaken < 9)
            {
                GetUserInput move = new GetUserInput();
                move.PrintInstructions();
                var userMove = move.UserInput();
                if (!userMove.Equals(Tuple.Create(-1,-1)))
                {
                    while (board.IsLocationTaken(userMove))
                    {
                        Console.WriteLine("This location is taken");
                        move.PrintInstructions();
                        userMove = move.UserInput();
                    }

                    board.AddMove(userMove);
                    seeBoard.PrintBoard(board);
                    if(!computer.IsBoardFull(board))
                        board.AddMove(computer.FindAvailableSpace(board), true);
                    seeBoard.PrintBoard(board);
                }
              
            }
            Console.WriteLine("Looks like no party won the game\nimprove your game next time");

        }
    }
}