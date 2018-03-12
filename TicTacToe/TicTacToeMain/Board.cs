using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class Board
    {
        public readonly int[,] Locations = new int[3,3];
        public int SpacesTaken = 0;
        private readonly List<Tuple<int, int>> _userMovesList = new List<Tuple<int, int>>();
        private readonly List<Tuple<int, int>> _computerMovesList = new List<Tuple<int, int>>();

        public void AddMove(Tuple<int,int> location, bool isComputer = false)
        {
            
            SpacesTaken += 1;
            int marker;
            switch (isComputer)
            {
                case true:
                    marker = 2;
                    _computerMovesList.Add(location);
                    break;
                default:
                    marker = 1;
                    _userMovesList.Add(location);
                    break;
            }
            
            var x = location.Item1-1; //subtracted 1 to start from 0
            var y = location.Item2-1;
            Locations[x,y] = marker;
        }
        public bool IsLocationTaken(Tuple<int,int> loc)
        {
            var place = Locations[loc.Item1-1, loc.Item2-1];
            return place == 1 || place == 2;
        }

        public bool DidUserWin()
        {
            var user = new WinningMoves(_userMovesList);
            return user.CheckWin();
        }

        public bool DidComputerWin()
        {
            var user = new WinningMoves(_computerMovesList);
            return user.CheckWin();
        }

        public bool IsAvailableBoardSpace()
        {
            return SpacesTaken < 9;
        }
        
    }
}