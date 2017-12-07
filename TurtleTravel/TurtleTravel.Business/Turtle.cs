using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTravel.Business
{
    using Interfaces;
    public class Turtle : ITurtle
    {                
        public string Warning { get; set; }

        private TablePosition currentPosition;
        private bool kickedOff;
        const int XMaxPosition = 5;
        const int XMinPosition = 0;
        const int YMaxPosition = 5;
        const int YMinPosition = 0;

        public Turtle()
        {
            this.currentPosition.XPosition = XMinPosition;
            this.currentPosition.YPosition = YMinPosition;
            this.currentPosition.FacingDirection = Directions.North;
            Warning = string.Empty;
        }

        public void Place(int X, int Y, string Facing)
        {
            this.kickedOff = true;

            this.currentPosition.XPosition = X;
            this.currentPosition.YPosition = Y;

            switch (Facing.ToLower())
            {
                case "north":
                    this.currentPosition.FacingDirection = Directions.North;
                    break;
                case "east":
                    this.currentPosition.FacingDirection = Directions.East;
                    break;
                case "south":
                    this.currentPosition.FacingDirection = Directions.South;
                    break;
                case "west":
                    this.currentPosition.FacingDirection = Directions.West;
                    break;
                default:
                    this.currentPosition.FacingDirection = Directions.North;
                    break;
            }

            ValidateEdges();
        }

        public void Move()
        {
            if (!IsKickedOff()) return;

            switch (this.currentPosition.FacingDirection)
            {
                case Directions.North:
                    this.currentPosition.YPosition++;
                    break;
                case Directions.East:
                    this.currentPosition.XPosition++;
                    break;
                case Directions.South:
                    this.currentPosition.YPosition--;
                    break;
                case Directions.West:
                    this.currentPosition.XPosition--;
                    break;
                default:
                    break;
            }

            ValidateEdges();
        }

        public void Left()
        {
            Rotate("Left");
        }

        public void Right()
        {
            Rotate("Right");            
        }

        public TablePosition Report()
        {
            //IsKickedOff();

            return this.currentPosition;
        }

        private void Rotate(string Side)
        {
            if (!IsKickedOff()) return;

            bool isRight = Side == "Right";

            switch (this.currentPosition.FacingDirection)
            {
                case Directions.North:
                    this.currentPosition.FacingDirection = isRight ? Directions.East : Directions.West;
                    break;
                case Directions.East:
                    this.currentPosition.FacingDirection = isRight ? Directions.South : Directions.North;
                    break;
                case Directions.South:
                    this.currentPosition.FacingDirection = isRight ? Directions.West : Directions.East;
                    break;
                case Directions.West:
                    this.currentPosition.FacingDirection = isRight ? Directions.North : Directions.South;
                    break;
                default:
                    break;
            }
        }

        private bool IsKickedOff()
        {
            Warning = this.kickedOff ? string.Empty : "PLACE command needs to be initiated";
            return this.kickedOff;
        }

        private void ValidateEdges()
        {
            string Edge = string.Empty;

            Warning = string.Empty;            

            if (this.currentPosition.XPosition < XMinPosition)
            {
                Edge = "West";
                this.currentPosition.XPosition = XMinPosition;
            }
            else if (this.currentPosition.XPosition > XMaxPosition)
            {
                Edge = "East";
                this.currentPosition.XPosition = XMaxPosition;
            }
            else if (this.currentPosition.YPosition < YMinPosition)
            {
                Edge = "South";
                this.currentPosition.YPosition = YMinPosition;
            }
            else if (this.currentPosition.YPosition > YMaxPosition)
            {
                Edge = "North";
                this.currentPosition.YPosition = YMaxPosition;
            }

            Warning = string.IsNullOrEmpty(Edge) ? Warning : "Reached " + Edge.ToUpper() + " end";
        }
    }

    public enum Directions
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4
    }

    public struct TablePosition
    {
        public int XPosition;

        public int YPosition;

        public Directions FacingDirection;

    }
}
