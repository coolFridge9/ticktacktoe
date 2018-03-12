using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeMain
{
    public class WinningMoves
    {
        private readonly List<Tuple<int, int>> _movesList;
        public WinningMoves(List<Tuple<int, int>> movesList)
        {
            this._movesList = movesList;
        }

        private bool CheckStraightWin()
        {
            var xMoves = _movesList.OrderBy(i => i.Item1).ToList();
            var yMoves = _movesList.OrderBy(i => i.Item2).ToList();
            var countX = 0;
            var countY = 0;
            for (var i = 1; i < _movesList.Count; i++)
            {
                if (xMoves[i].Item1 == xMoves[i - 1].Item1)
                    countX += 1;
                if (yMoves[i].Item2 == yMoves[i - 1].Item2)
                    countY += 1;
                if (countX == 2|| countY == 2)
                    return true;
            }

            return false;
        }

        private bool CheckDiagonalWin()
        {
            var moves = _movesList.OrderBy(i => i.Item1).ToList();

            var win1 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 3)
            };
            var win2 = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 1)
            };

            return ContainsAllItems(moves, win1) || ContainsAllItems(moves, win1);
        }

        public bool CheckWin()
        {
            return CheckDiagonalWin() || CheckStraightWin();
        }

        private static bool ContainsAllItems<T>(IEnumerable<T> a, IEnumerable<T> b)
        {
            return !b.Except(a).Any();
        }

    }
}