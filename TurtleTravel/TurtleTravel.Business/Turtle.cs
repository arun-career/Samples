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
        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public Directions FacingDirection { get; set; }

        public string Warning { get; set; }

        private bool _kickedOff;

        public Turtle()
        {
            XPosition = 0;
            YPosition = 0;
            FacingDirection = Directions.North;
        }

        public void Place(int X, int Y, string Facing)
        {
            //throw new NotImplementedException();
            _kickedOff = true;

            XPosition = X;
            YPosition = Y;

            switch (Facing.ToLower())
            {
                case "north":
                    FacingDirection = Directions.North;
                    break;
                case "east":
                    FacingDirection = Directions.East;
                    break;
                case "south":
                    FacingDirection = Directions.South;
                    break;
                case "west":
                    FacingDirection = Directions.West;
                    break;
                default:
                    FacingDirection = Directions.North;
                    break;
            }


            ValidateEdges();
        }

        public void Move()
        {
            //throw new NotImplementedException();

            if (!IsKickedOff()) return;

            switch (FacingDirection)
            {
                case Directions.North:
                    YPosition++;
                    break;
                case Directions.East:
                    XPosition++;
                    break;
                case Directions.South:
                    YPosition--;
                    break;
                case Directions.West:
                    XPosition--;
                    break;
                default:
                    break;
            }

            ValidateEdges();
        }

        public void Left()
        {
            //throw new NotImplementedException();

            if (!IsKickedOff()) return;

            switch (FacingDirection)
            {
                case Directions.North:
                    FacingDirection = Directions.West;
                    break;
                case Directions.East:
                    FacingDirection = Directions.North;
                    break;
                case Directions.South:
                    FacingDirection = Directions.East;
                    break;
                case Directions.West:
                    FacingDirection = Directions.South;
                    break;
                default:
                    break;
            }
        }

        public void Right()
        {
            //throw new NotImplementedException();

            if (!IsKickedOff()) return;

            switch (FacingDirection)
            {
                case Directions.North:
                    FacingDirection = Directions.East;
                    break;
                case Directions.East:
                    FacingDirection = Directions.South;
                    break;
                case Directions.South:
                    FacingDirection = Directions.West;
                    break;
                case Directions.West:
                    FacingDirection = Directions.North;
                    break;
                default:
                    break;
            }
        }

        public Turtle Report()
        {
            IsKickedOff();

            return this;
        }

        private bool IsKickedOff()
        {
            Warning = _kickedOff ? string.Empty : "Place command needs to be initiated";
            return _kickedOff;
        }

        private void ValidateEdges()
        {
            string Edge = string.Empty;

            Warning = string.Empty;            

            if (XPosition < 0)
            {
                Edge = "West";
                XPosition = 0;
            }
            else if (XPosition > 5)
            {
                Edge = "East";
                XPosition = 5;
            }
            else if (YPosition < 0)
            {
                Edge = "South";
                YPosition = 0;
            }
            else if (YPosition > 5)
            {
                Edge = "North";
                YPosition = 5;
            }

            Warning = string.IsNullOrEmpty(Edge) ? Warning : "Reached " + Edge + " end";
        }
    }

    public enum Directions
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4
    }
}
