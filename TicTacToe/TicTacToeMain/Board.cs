using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class Board
    {
        public const int SizeOfBoard = 5;
        public readonly int[,] Locations = new int[SizeOfBoard,SizeOfBoard];
        public int SpacesTaken = 0;
        public static List<Tuple<int, int>> UserMovesList { get; } = new List<Tuple<int, int>>();
        private readonly List<Tuple<int, int>> _computerMovesList = new List<Tuple<int, int>>();
        public static readonly Tuple<int, int> QuitMove = Tuple.Create(-1, -1);
        //public Tuple<int, int> MostRecentUserMove = new Tuple<int, int>(0,0);

        private enum Players
        {
            Blank,
            User,
            Computer
        }

        public void AddMove(Tuple<int,int> location, bool isComputer = false)
        {
            
            SpacesTaken += 1;
            int marker;
            switch (isComputer)
            {
                case true:
                    marker = (int)Players.Computer;
                    _computerMovesList.Add(location);
                    break;
                default:
                    marker = (int) Players.User;
                    UserMovesList.Add(location);
                    //MostRecentUserMove = location;
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

        public static bool DidUserWin()
        {
            var user = new WinningMoves(UserMovesList);
            return user.CheckWin();
        }

        public bool DidComputerWin()
        {
            var user = new WinningMoves(_computerMovesList);
            return user.CheckWin();
        }

        public bool HasEmptySpaces()
        {
            const int boardSpace = SizeOfBoard * SizeOfBoard;
            return SpacesTaken < boardSpace;
        }

        public static bool DidUserQuit(Tuple<int,int> userMove)
        {
            return userMove.Equals(QuitMove);
            
        }
        
    }
}