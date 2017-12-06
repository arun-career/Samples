using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTravel.Console
{
    using System;
    using TurtleTravel.Business;


    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = string.Empty;
            string inputCommandText = "------INPUT------";
            int xPosition = 0, yPosition = 0;
            string facingDirection = "North";

            Console.WriteLine(inputCommandText);
            inputCommand = Console.ReadLine();

            string[] inputCommandParts = inputCommand.Split(' ');

            while (inputCommandParts.Length != 2 || inputCommandParts[0].ToUpper() != "PLACE")
            {
                Console.WriteLine("Initial command needs to PLACE (e.g. PLACE 3,4,SOUTH)");
                Console.WriteLine(inputCommandText);
                inputCommand = Console.ReadLine();
                inputCommandParts = inputCommand.Split(' ');
            }

            string inputCommandSecondPart = inputCommandParts[1];
            string[] inputCommandSecondParts = inputCommandParts[1].Split(',');

            int.TryParse(inputCommandSecondParts[0].Trim(), out xPosition);
            int.TryParse(inputCommandSecondParts[1].Trim(), out yPosition);
            facingDirection = inputCommandSecondParts[2];

            Turtle NinjaTurtle = new Turtle();
            NinjaTurtle.Place(xPosition, yPosition, facingDirection);

            inputCommand = Console.ReadLine();

            while (inputCommand.ToUpper() != "REPORT")
            {
                switch (inputCommand.ToUpper())
                {
                    case "MOVE":
                        NinjaTurtle.Move();
                        break;
                    case "LEFT":
                        NinjaTurtle.Left();
                        break;
                    case "RIGHT":
                        NinjaTurtle.Right();
                        break;
                    default:
                        break;
                }

                inputCommand = Console.ReadLine();
            }

            Console.WriteLine("------OUTPUT------");
            Console.WriteLine("{0},{1},{2}",NinjaTurtle.Report().XPosition, NinjaTurtle.Report().YPosition, NinjaTurtle.Report().FacingDirection);
            Console.ReadLine();
        }
    }
}
