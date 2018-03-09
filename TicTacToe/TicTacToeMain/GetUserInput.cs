using System;
using System.Text.RegularExpressions;

namespace TicTacToeMain
{
    public class GetUserInput
    {
        
        public void PrintInstructions()
        {
            Console.Write("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
        }

        public string ReadUserInput()
        {
            var input = Console.ReadLine();
            return input;
        }
        
        
        public Tuple<int,int> UserInput()
        {
            string coordinates = ReadUserInput();
            
            while (!ValidateInput(coordinates))
            {
                Console.WriteLine("invalid move");
                PrintInstructions();
                coordinates = ReadUserInput(); 
            }
            return CoordinatesToTuple(coordinates);

        }

        public Boolean ValidateInput(string coordinates)
        {
            Regex format = new Regex("[1-3],[1-3]");
            return (format.IsMatch(coordinates))|| coordinates=="q"; 
        }

        public Tuple<int, int> CoordinatesToTuple(string coordinateString)
        {
            var x =-1;
            var y =-1;
            if (coordinateString != "q")
            {
                var splitCoordinates = coordinateString.Split(',');
                x = int.Parse(splitCoordinates[0]);
                y = int.Parse(splitCoordinates[1]);
            }

            return Tuple.Create(x,y);
        }
        
        
        

    }
}