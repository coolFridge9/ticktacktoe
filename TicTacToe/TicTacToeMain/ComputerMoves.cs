using System;
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

       /* public static Tuple<int, int> FindLogicalSpace(Board board)
        {
            
            
        }*/

        public static Tuple<int, int> FindRandomSpace(Board board)
        {
            var randNumMaker = new Random();
            var x = randNumMaker.Next(1, Board.SizeOfboard);
            var y = randNumMaker.Next(1, Board.SizeOfboard);
            while (board.IsLocationTaken(Tuple.Create(x, y)))
            {
                x = randNumMaker.Next(1, Board.SizeOfboard); // instead get avail space list
                y = randNumMaker.Next(1, Board.SizeOfboard);
            }


            return Tuple.Create(x, y);
        }
        

    }
}