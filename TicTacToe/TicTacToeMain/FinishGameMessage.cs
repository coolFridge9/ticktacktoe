using System;

namespace TicTacToeMain
{
    public class FinishGameMessage
    {
        private readonly bool _compWin;
        private readonly bool _userWin;

        public FinishGameMessage(bool userWin, bool compWin)
        {
            this._userWin = userWin;
            this._compWin = compWin;
            Decide();
        }

        private void Decide()
        {
            if(_userWin)
                Console.WriteLine("Congradulations! you are the ultimate winner");
            else if(_compWin)
                Console.WriteLine("I cant believe you lost smh");
            else
            {
                Console.WriteLine("\nLooks like no party won the game\nimprove your game next time");
            }
        }
    }
}