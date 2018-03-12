using System;

namespace TicTacToeMain
{
    public class DisplayBoard
    {
        public DisplayBoard(Board board)
        {
            PrintBoard(board);
        }
        public static void PrintBoard(Board board)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var k = 0; k < 3; k++)
                {
                    var symbol = '.';
                    switch (board.locations[i, k])
                    {
                        case 1:
                            symbol = 'x';
                            break;
                        case 2:
                            symbol = 'o';
                            break;
                    }

                    Console.Write(symbol);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}