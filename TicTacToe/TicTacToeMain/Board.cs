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
            
            SpacesTaken += 1;
            int marker;
            switch (isComputer)
            {
                case true:
                    marker = 2;
                    ComputerMovesList.Add(location);
                    break;
                default:
                    marker = 1;
                    UserMovesList.Add(location);
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
            Console.WriteLine(user.CheckWin());
            return user.CheckWin();

        }

        public bool DidComputerWin()
        {
            var user = new WinningMoves(ComputerMovesList);
            Console.WriteLine(user.CheckWin());
            return user.CheckWin();
        }
        
    }
}