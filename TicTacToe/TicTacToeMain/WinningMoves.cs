using System;
using System.Collections.Generic;
namespace TicTacToeMain
{
    public class WinningMoves
    {
        public List<Tuple<int, int>> MovesList = new List<Tuple<int, int>>();
        public WinningMoves(List<Tuple<int, int>> MovesList)
        {
            this.MovesList = MovesList;
        }
        public bool CheckStraightWin(Board board)
        {
            for (int i = 0; i < MovesList.Count; i++)
            {
                Console.WriteLine(MovesList[i]);
            }

            return true;
        }
        
        //public bool 
    }
}