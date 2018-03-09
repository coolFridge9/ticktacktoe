using System;
using System.Collections.Generic;
namespace TicTacToeMain
{
    public class WinningMoves
    {
        public List<Tuple<int, int>> UserMovesList = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> ComputerMovesList = new List<Tuple<int, int>>();
        public WinningMoves(List<Tuple<int, int>> UserMovesList, List<Tuple<int, int>> ComputerMovesList)
        {
            this.UserMovesList = UserMovesList;
            this.ComputerMovesList = ComputerMovesList;
        }
        public bool CheckStraightWin(Board board)
        {
            //board.locations
        }
        
        public bool 
    }
}