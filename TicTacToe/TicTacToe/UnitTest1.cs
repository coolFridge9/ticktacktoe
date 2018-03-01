using System;
using TicTacToeMain;
using Xunit;

namespace TicTacToe
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("1,1")]
        [InlineData("1,3")]
        [InlineData("2,2")]
        public void CorrectInputFormat(string coordinatesString)
        {
            var userInput = new GetUserInput();
            var result = userInput.ValidateInput(coordinatesString);
            Assert.True(result);
            //Assert.True(true);
            
            
        }
        [Theory]
        [InlineData("")]
        [InlineData("1,7")]
        [InlineData("0,2")]
        public void IncorrectInputFormat(string coordinatesString)
        {
            var userInput = new GetUserInput();
            var result = userInput.ValidateInput(coordinatesString);
            Assert.False(result);
            
        }
//        CoordinatesToTuple
        [Theory]
        [InlineData("1,1",1,1)]
        [InlineData("2,2",2,2)]
        [InlineData("1,3",1,3)]
        public void InputStringOutputTuple(string coordinatesString, int x, int y)
        {
            var userInput = new GetUserInput();
            var result = userInput.CoordinatesToTuple(coordinatesString);
            var newTuple = Tuple.Create(x, y);
            Assert.Equal(newTuple, result);

        }
    }
}