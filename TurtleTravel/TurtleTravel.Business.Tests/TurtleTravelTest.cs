using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurtleTravel.Business.Tests
{
    [TestClass]
    public class TurtleTravelTest
    {
        [TestMethod]
        public void Test_Check_Default_Positions_Are_0and0_Facing_North()
        {
            Turtle SteadyTurtle = new Turtle();

            Assert.AreEqual(0, SteadyTurtle.XPosition);
            Assert.AreEqual(0, SteadyTurtle.YPosition);
            Assert.AreEqual(Directions.North, SteadyTurtle.FacingDirection);
        }

        [TestMethod]
        public void Test_Check_Place_Command_Is_The_First_Valid_Command()
        {
            Turtle NinJa = new Turtle();

            Assert.AreEqual(0, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.North, NinJa.FacingDirection);

            NinJa.Move();

            Assert.AreEqual(0, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.North, NinJa.FacingDirection);            
        }        

        [TestMethod]
        public void Test_Check_Move_Forwards_1_Unit_Without_Changing_Direction()
        {
            Turtle NinJa = new Turtle();

            NinJa.Place(0, 0, "North");
            NinJa.Move();

            Assert.AreEqual(0, NinJa.XPosition);
            Assert.AreEqual(1, NinJa.YPosition);
            Assert.AreEqual(Directions.North, NinJa.FacingDirection);
        }

        [TestMethod]
        public void Test_Check_Left_Turns_90_Degree_Left_Without_Changing_Position()
        {
            Turtle NinJa = new Turtle();

            NinJa.Place(0, 0, "North");
            NinJa.Left();

            Assert.AreEqual(0, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.West, NinJa.FacingDirection);
        }

        [TestMethod]
        public void Test_Check_Right_Turns_90_Degree_Right_Without_Changing_Position()
        {
            Turtle NinJa = new Turtle();

            NinJa.Place(0, 0, "North");
            NinJa.Right();

            Assert.AreEqual(0, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.East, NinJa.FacingDirection);
        }

        [TestMethod]
        public void Test_Check_Place_Places_In_The_Specified_Positions_And_Direction()
        {
            Turtle NinJa = new Turtle();

            Assert.AreEqual(0, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.North, NinJa.FacingDirection);

            NinJa.Place(3, 4, "East");

            Assert.AreEqual(3, NinJa.XPosition);
            Assert.AreEqual(4, NinJa.YPosition);
            Assert.AreEqual(Directions.East, NinJa.FacingDirection);
        }

        [TestMethod]
        public void Test_Check_Turtle_Is_Prevented_From_Falling_From_Edges()
        {
            Turtle NinJa = new Turtle();

            Assert.AreEqual(0, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.North, NinJa.FacingDirection);

            NinJa.Place(5, 3, "East");

            Assert.AreEqual(5, NinJa.XPosition);
            Assert.AreEqual(3, NinJa.YPosition);
            Assert.AreEqual(Directions.East, NinJa.FacingDirection);
            Assert.AreEqual(string.Empty, NinJa.Warning);

            NinJa.Move();

            Assert.AreEqual(5, NinJa.XPosition);
            Assert.AreEqual(3, NinJa.YPosition);
            Assert.AreEqual(Directions.East, NinJa.FacingDirection);
            Assert.AreNotEqual(string.Empty, NinJa.Warning);

            NinJa.Place(4, 0, "South");

            Assert.AreEqual(4, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.South, NinJa.FacingDirection);
            Assert.AreEqual(string.Empty, NinJa.Warning);

            NinJa.Move();

            Assert.AreEqual(4, NinJa.XPosition);
            Assert.AreEqual(0, NinJa.YPosition);
            Assert.AreEqual(Directions.South, NinJa.FacingDirection);
            Assert.AreNotEqual(string.Empty, NinJa.Warning);
        }
    }
}
