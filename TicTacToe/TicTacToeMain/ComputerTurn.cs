using System;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class ComputerTurn
    {
        public static Tuple<int, int> FindAvailableSpace(Board board) 
        {
            for (var i = 1; i <= 3; i++)
            {
                for (var k = 1; k <= 3; k++)
                {
                    if (!board.IsLocationTaken(Tuple.Create(i,k)))
                        return Tuple.Create(i, k);

                }
            } 
            return Tuple.Create(-1, -1);
        }

        public static bool IsBoardFull(Board board)
        {
            return board.SpacesTaken == 9;
        }
        
        
    }
}