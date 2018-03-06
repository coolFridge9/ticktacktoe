using System;

namespace TicTacToeMain
{
    public class DisplayBoard
    {
        public void PrintBoard(Board board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    char symbol = '.';
                    if (board.locations[i, k] == 1)
                        symbol = 'x';
                    if (board.locations[i, k] == 2)
                        symbol = 'o';
                    Console.Write(symbol);
                }
                Console.WriteLine("");
            }
        }
    }
}