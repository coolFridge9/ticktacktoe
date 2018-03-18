﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace TicTacToeMain
{
    public class Board
    {
        public const int SizeOfboard = 3;
        public readonly int[,] Locations = new int[SizeOfboard,SizeOfboard];
        public int SpacesTaken = 0;
        private readonly List<Tuple<int, int>> _userMovesList = new List<Tuple<int, int>>();
        private readonly List<Tuple<int, int>> _computerMovesList = new List<Tuple<int, int>>();
        public static readonly Tuple<int, int> QuitMove = Tuple.Create(-1, -1);

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
            const int boardSpace = SizeOfboard * SizeOfboard;
            return SpacesTaken < boardSpace;
        }

        public static bool DidUserQuit(Tuple<int,int> userMove)
        {
            return userMove.Equals(QuitMove);
            
        }
        
    }
}