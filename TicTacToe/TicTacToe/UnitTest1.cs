using System;
using TicTacToeMain;
using Xunit;

namespace TicTacToe
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var userInput = new GetUserInput();
            var result = userInput.UserInput();
        }
    }
}