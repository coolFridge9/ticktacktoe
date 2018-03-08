using System;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class ComputerTurn
    {
        private Board board;
        
        public ComputerTurn(Board board)
        {
            this.board = board;
            
        }

        public Tuple<int, int> FindAvailableSpace() //write test
        {
            for (int i = 1; i <= 3; i++)
            {
                for (int k = 1; k <= 3; k++)
                {
                    if (!board.IsLocationTaken(Tuple.Create(i,k)))
                        return Tuple.Create(i, k);

                }
            } 
            return Tuple.Create(-1, -1);
        }
        
        
    }
}