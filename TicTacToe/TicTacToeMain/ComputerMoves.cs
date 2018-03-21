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
        private static Board _board = new Board();
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

        /*public static Tuple<int, int> MoveToBlockOpponent(Board board)
        {
            _board = board;
            var listOfSpaces = GetListOfAvailableSpaces(board);
            if (CheckIfCanWin())
                return GetWinningMove();
            if (CheckIfCanBlock())
                return GetBlockingMove();
            if (IsMiddleSquareTaken())
                return GetMiddleSquare();
            else
            {
                return FindRandomSpace(board);
            }            
            
        }*/

        public void reallyGoodAiMove()
        {
            
        }

        private static Tuple<int, int> GetMiddleSquare()
        {
            return Tuple.Create(Board.SizeOfBoard/2, Board.SizeOfBoard/2);
        }

        private static bool IsMiddleSquareTaken()
        {
            return _board.IsLocationTaken(GetMiddleSquare());
        }

        private static Tuple<int, int> GetBlockingMove()
        {
            throw new NotImplementedException();
        }

        private static bool CheckIfCanBlock()
        {
            throw new NotImplementedException();
        }

        /*private static Tuple<int, int> GetWinningMove()
        {
            var listOfSpaces = GetListOfAvailableSpaces(_board);
            foreach (var move in listOfSpaces)
            {
                var winDecider = new WinningMoves(_board.UserMovesList);
                if (WinningMoves.CheckPontentialWin(move))
                    return move;
            }

            return Tuple.Create(-1, -1);
        }

        private static bool CheckIfCanWin()
        {
            var winningMove = GetWinningMove();
            return !Equals(winningMove, Tuple.Create(-1, -1));
        }*/

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