namespace TurtleTravel.Console
{
    using System;
    using TurtleTravel.Business.Interfaces;
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
                Console.WriteLine("Initial command needs to be a valid PLACE command (e.g. PLACE 3,4,SOUTH)");
                Console.WriteLine(inputCommandText);
                inputCommand = Console.ReadLine();
                inputCommandParts = inputCommand.Split(' ');
            }

            string inputCommandSecondPart = inputCommandParts[1];
            string[] inputCommandSecondParts = inputCommandParts[1].Split(',');

            int.TryParse(inputCommandSecondParts[0].Trim(), out xPosition);
            int.TryParse(inputCommandSecondParts[1].Trim(), out yPosition);
            facingDirection = inputCommandSecondParts[2];

            //Due to the deliverable constraint (no other dependences apart from unit test), 
            //implementation of DI (Dependency Injection) has been avoided here.
            ITurtle NinjaTurtle = new Turtle();

            NinjaTurtle.Place(xPosition, yPosition, facingDirection);

            inputCommand = Console.ReadLine();

            while (inputCommand.ToUpper() != "EXIT")
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
                    case "REPORT":
                        TablePosition currentPosition = NinjaTurtle.Report();

                        Console.WriteLine("------OUTPUT------");
                        Console.WriteLine("{0},{1},{2}", currentPosition.XPosition, currentPosition.YPosition, currentPosition.FacingDirection.ToString().ToUpper());

                        if (!string.IsNullOrEmpty(NinjaTurtle.Warning))
                        {
                            Console.WriteLine("Warning: {0}", NinjaTurtle.Warning);
                        }

                        break;
                    default:
                        break;
                }

                inputCommand = Console.ReadLine();
            }

            Console.WriteLine("------EXITED------");
            Console.ReadLine();
        }
    }
}
