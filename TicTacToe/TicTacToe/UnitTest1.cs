using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
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
        [InlineData("q")]
        public void CorrectInputFormat(string coordinatesString)
        {
            var userInput = new UserInputHandler();
            var result = UserInputHandler.ValidateInput(coordinatesString);
            Assert.True(result);
            
            
            
        }
        [Theory]
        [InlineData("")]
        [InlineData("1,7")]
        [InlineData("0,2")]
        public void IncorrectInputFormat(string coordinatesString)
        {
            var userInput = new UserInputHandler();
            var result = UserInputHandler.ValidateInput(coordinatesString);
            Assert.False(result);
            
        }
//        CoordinatesToTuple
        [Theory]
        [InlineData("1,1",1,1)]
        [InlineData("2,2",2,2)]
        [InlineData("1,3",1,3)]
        public void InputStringOutputTuple(string coordinatesString, int x, int y)
        {
            var userInput = new UserInputHandler();
            var result = UserInputHandler.CoordinatesToTuple(coordinatesString);
            var newTuple = Tuple.Create(x, y);
            Assert.Equal(newTuple, result);

        }

        [Theory]
        [InlineData(1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0)]
        [InlineData(3, 2, 0, 0, 0, 0, 0, 0, 0, 1, 0)]

        public void CheckBoardIsCorrectAfterMove(int x, int y, int loc00, int loc01, int loc02, int loc10, int loc11,
            int loc12, int loc20, int loc21, int loc22)
        {
            var board = new Board();
            board.AddMove( Tuple.Create(x,y), false);
            var result = board.Locations;
            Assert.Equal(result[0,0],loc00);
            Assert.Equal(result[0,1],loc01);
            Assert.Equal(result[0,2],loc02);
            Assert.Equal(result[1,0],loc10);
            Assert.Equal(result[1,1],loc11);
            Assert.Equal(result[1,2],loc12);
            Assert.Equal(result[2,0],loc20);
            Assert.Equal(result[2,1],loc21);
            Assert.Equal(result[2,2],loc22);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,3)]
        public void IsThisPlaceTaken(int x, int y)
        {
            var board = new Board();
            var allowed = board.IsLocationTaken(Tuple.Create(x, y));
            board.AddMove(Tuple.Create(x,y),true);
            Assert.Equal(2,board.Locations[x-1,y-1]);
            var notAllowed = board.IsLocationTaken(Tuple.Create(x, y));
            Assert.False(allowed);
            Assert.True(notAllowed);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        public void CheckLocationIsTaken(int x, int y)
        {
            var board= new Board();
            board.AddMove(Tuple.Create(2,2));
            board.AddMove(Tuple.Create(1,1));
            Boolean isItTaken = board.IsLocationTaken(Tuple.Create(x,y));
            Assert.True(isItTaken);
        }
        
        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        public void CheckLocationIsNotTaken(int x, int y)
        {
            var board= new Board();
            var isItTaken = board.IsLocationTaken(Tuple.Create(x,y));
            Assert.False(isItTaken);
        }

        [Fact]
        public void FindingCorrectFreeSpace()
        {
            Board board = new Board();
            board.AddMove(Tuple.Create(2,2),false);
            board.AddMove(Tuple.Create(1,1),false);
            var compTurn = new ComputerMoves();
            var freeSpace = ComputerMoves.FindAvailableSpace(board);
            Assert.Equal(Tuple.Create(1, 2),freeSpace);
        }
        
    }
}