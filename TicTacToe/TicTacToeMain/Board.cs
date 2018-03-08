using System;

namespace TicTacToeMain
{
    public class Board
    {
        public int[,] locations = new int[3,3];
        public int spacesTaken = 0;

        public void AddMove(Tuple<int,int> location, Boolean isComputer = false)
        {
            spacesTaken += 1;
            int marker;
            switch (isComputer)
            {
                case true:
                    marker = 2;
                    break;
                default:
                    marker = 1;
                    break;
            }
            
            int x = location.Item1-1; //subtracted 1 to start from 0
            int y = location.Item2-1;
            locations[x,y] = marker;
        }
        public bool IsLocationTaken(Tuple<int,int> loc)
        {
            int place = locations[loc.Item1-1, loc.Item2-1];
            if (place == 1 || place == 2)
            {
                return true;
            }

            return false;

        }
        
    }
    
}