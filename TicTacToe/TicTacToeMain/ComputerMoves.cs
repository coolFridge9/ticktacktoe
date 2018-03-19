using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class ComputerMoves
    {
        public static Tuple<int, int> FindAvailableSpace(Board board) 
        {
            for (var i = 1; i <= Board.SizeOfboard; i++)
            {
                for (var k = 1; k <= Board.SizeOfboard; k++)
                {
                    if (!board.IsLocationTaken(Tuple.Create(i,k)))
                        return Tuple.Create(i, k);

                }
            } 
            return Board.QuitMove;
        }

        public static Tuple<int, int> MoveToBlockOpponent(Board board)
        {
            var listOfSpaces = GetListOfAvailableSpaces(board);
            
            
            return Tuple.Create(0, 0);
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
            for (var i = 1; i <= Board.SizeOfboard; i++)
            {
                for (var k = 1; k <= Board.SizeOfboard; k++)
                {
                    if (!board.IsLocationTaken(Tuple.Create(i,k)))
                        listOfAvailableSpaces.Add( Tuple.Create(i, k));

                }
            }

            return listOfAvailableSpaces;
        }
        

    }
}