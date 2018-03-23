using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class ComputerMoves
    {
        private Board board = new Board();
        private Tuple<int, int> doesntExist = Tuple.Create(-1, -1);
        public static Tuple<int, int> FindAvailableSpace(Board board) 
        {
            for (var i = 1; i <= Board.SizeOfBoard; i++)
            {
                for (var k = 1; k <= Board.SizeOfBoard; k++)
                {
                    if (!board.IsLocationTaken(Tuple.Create(i,k)))
                        return Tuple.Create(i, k);

                }
            } 
            return Board.QuitMove;
        }

        public Tuple<int, int> MoveToBlockOpponent(Board board)
        {
            this.board = board;
            var listOfSpaces = GetListOfAvailableSpaces(board);
            /*if (CheckIfCanWin())
                return GetWinningMove();
            if (CheckIfCanBlock())
                return GetBlockingMove();
            if (IsMiddleSquareTaken())
                return GetMiddleSquare();
            return FindRandomSpace(board);*/

            var winningMove = GetWinningMove();
            if (winningMove != doesntExist)
                return winningMove;

            var blockMove = GetBlockingMove();
            if (blockMove != doesntExist)
                return blockMove;
            
            if (!IsMiddleSquareTaken())
                return GetMiddleSquare();
            
            return FindRandomSpace(board);
        }


        private static Tuple<int, int> GetMiddleSquare() //not working
        {
            var mid2 = Tuple.Create(Board.SizeOfBoard/2+1, Board.SizeOfBoard/2+1);
            return Tuple.Create(Board.SizeOfBoard/2+1, Board.SizeOfBoard/2+1); //maybe make a case for even and odd sizes
        }

        private bool IsMiddleSquareTaken()
        {
            var isIT = board.IsLocationTaken(GetMiddleSquare());
            var mid = GetMiddleSquare();
            return board.IsLocationTaken(GetMiddleSquare());
        }

        private Tuple<int, int> GetBlockingMove()
        {
            var listOfSpaces = GetListOfAvailableSpaces(board);
            foreach (var move in listOfSpaces)
            {
                var winDecider = new WinningMoves(board.ComputerMovesList);
                if (winDecider.CheckPontentialWinWhenMoveAdded(move))
                    return move;
            }

            return doesntExist;
        }

        private bool CheckIfCanBlock()
        {
            var winningMove = GetBlockingMove();
            return !Equals(winningMove, doesntExist);
        }

        private Tuple<int, int> GetWinningMove()
        {
            var listOfSpaces = GetListOfAvailableSpaces(board);
            foreach (var move in listOfSpaces)
            {
                var winDecider = new WinningMoves(board.UserMovesList);
                if (winDecider.CheckPontentialWinWhenMoveAdded(move))
                    return move;
            }

            return doesntExist;
        }

        private bool CheckIfCanWin()
        {
            var winningMove = GetWinningMove();
            return !Equals(winningMove, doesntExist);
        }

        public static Tuple<int, int> FindRandomSpace(Board board)
        {
            var randNumMaker = new Random();
            var listOfSpaces = GetListOfAvailableSpaces(board);
            var numOfAvailableSpaces = listOfSpaces.Count;
            var choice = randNumMaker.Next(numOfAvailableSpaces);
            return listOfSpaces[choice];
        }

        private static List<Tuple<int, int>> GetListOfAvailableSpaces(Board board)
        {
            var listOfAvailableSpaces = new List<Tuple<int, int>>();
            for (var i = 1; i <= Board.SizeOfBoard; i++)
            {
                for (var k = 1; k <= Board.SizeOfBoard; k++)
                {
                    if (!board.IsLocationTaken(Tuple.Create(i,k)))
                        listOfAvailableSpaces.Add( Tuple.Create(i, k));

                }
            }

            return listOfAvailableSpaces;
        }
        

    }
}