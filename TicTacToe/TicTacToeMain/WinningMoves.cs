using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TicTacToeMain
{
    public class WinningMoves
    {
        private const int NumberInARowToWin = Board.SizeOfBoard;
        private readonly List<Tuple<int, int>> _movesList;
        
        public WinningMoves(List<Tuple<int, int>> movesList)
        {
            this._movesList = movesList;
        }

        private bool CheckHorizontal()
        {
            var xAxisCoordinates = FlattenTupleListToListOfXCoordinates(_movesList);
            xAxisCoordinates.Sort();
            return CheckIfThereIsEnoughConsecutiveMoves(xAxisCoordinates);
        }
        
        private bool CheckVertical()
        {
            var yAxisCoordinates = FlattenTupleListToListOfYCoordinates(_movesList);
            yAxisCoordinates.Sort();
            return CheckIfThereIsEnoughConsecutiveMoves(yAxisCoordinates);
        }

        private bool CheckIfThereIsEnoughConsecutiveMoves(List<int> coordinateList)
        {
            var consecutiveCount = ResetCount();
            var amountOfMovesMade = _movesList.Count;
            
            for (var move = 1; move < amountOfMovesMade; move++)
            {
                var currentCoordinate = coordinateList[move];
                var previousCoordinate = coordinateList[move - 1];
                    
                if (currentCoordinate == previousCoordinate)
                    consecutiveCount += 1;
                else
                {
                    consecutiveCount = ResetCount();
                }
                
                if (consecutiveCount == NumberInARowToWin-1)
                    return true;
            }
            return false;
        }



        private List<int> FlattenTupleListToListOfXCoordinates(List<Tuple<int, int>> orderedMovesList)
        {
            var xCoordinates = new List<int>();
            foreach(var move in orderedMovesList)
            {
                xCoordinates.Add(move.Item1);
            }

            return xCoordinates;
        }
        
        private List<int> FlattenTupleListToListOfYCoordinates(List<Tuple<int, int>> orderedMovesList)
        {
            var xCoordinates = new List<int>();
            foreach(var move in orderedMovesList)
            {
                xCoordinates.Add(move.Item2);
            }

            return xCoordinates;
        }

        private int ResetCount()
        {
            return 0;
        }

        private bool CheckDiagonal()
        {
            var moves = _movesList.OrderBy(i => i.Item1).ToList();

            var win1 = new List<Tuple<int, int>> { };
            var win2 = new List<Tuple<int, int>> { };
            for (var i = 1; i <= NumberInARowToWin; i++)
            {
                win1.Add(new Tuple<int, int>(i, i));
                win2.Add(new Tuple<int, int>(i,NumberInARowToWin+1-i));
            }

            return ContainsAllItems(moves, win1) || ContainsAllItems(moves, win2);
        }

        public bool CheckWin()
        {
            return CheckDiagonal() || CheckHorizontal() || CheckVertical(); 
        }

        public bool CheckPontentialWinWhenMoveAdded(Tuple<int,int> potentialMove) 
        {
            _movesList.Add(potentialMove);
            var willWin = CheckWin();
            _movesList.RemoveAt(_movesList.Count-1);
            return willWin;
        }

        private static bool ContainsAllItems<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            return !b.Except(a).Any();
        }

    }
}