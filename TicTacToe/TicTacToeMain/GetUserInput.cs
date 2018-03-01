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

        public string ReadUserInput(string userinput)
        {
            return userinput;
        }
        
        
        
        public Tuple<int,int> UserInput()
        {

            Regex format = new Regex("[1-3],[1-3]");
            string coordinates = ReadUserInput();
            while (!format.IsMatch(coordinates))
            {
                Console.WriteLine("invalid move");
                PrintInstructions();
                coordinates = ReadUserInput(); 
            }

            var splitCoordinates = coordinates.Split(',');
            int x = Int32.Parse(splitCoordinates[0]);
            int y = Int32.Parse(splitCoordinates[1]);
            return Tuple.Create(x,y);
        }
        

    }
}