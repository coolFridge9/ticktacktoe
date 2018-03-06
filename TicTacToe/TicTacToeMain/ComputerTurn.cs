using System;
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
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (board.locations[i, k] == 0)
                        return Tuple.Create(i, k);
                    return Tuple.Create(-1, -1);

                }
            } 
        }
        
    }
}