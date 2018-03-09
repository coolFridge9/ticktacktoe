using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class Board
    {
        public int[,] locations = new int[3,3];
        public int SpacesTaken = 0;
        public List<Tuple<int, int>> UserMovesList = new List<Tuple<int, int>>();
        public List<Tuple<int, int>> ComputerMovesList = new List<Tuple<int, int>>();

        public void AddMove(Tuple<int,int> location, Boolean isComputer = false)
        {
            if (!isComputer)
                UserMovesList.Add(location);
            else
                ComputerMovesList.Add(location);
            
            SpacesTaken += 1;
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

        public bool DidUserWin()
        {
            var user = new WinningMoves(UserMovesList);
            return true;

        }
        
    }
}