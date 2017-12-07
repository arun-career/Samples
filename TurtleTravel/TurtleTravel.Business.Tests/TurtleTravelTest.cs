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

            TablePosition expected = GetExpectedTablePosition(0, 0, Directions.North);

            TablePosition actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Check_Place_Command_Is_The_First_Valid_Command()
        {
            Turtle SteadyTurtle = new Turtle();

            TablePosition expected = GetExpectedTablePosition(0, 0, Directions.North);

            TablePosition actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);

            SteadyTurtle.Move();
            actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
        }        

        [TestMethod]
        public void Test_Check_Move_Forwards_1_Unit_Without_Changing_Direction()
        {
            Turtle SteadyTurtle = new Turtle();
            TablePosition expected = GetExpectedTablePosition(0, 1, Directions.North);

            SteadyTurtle.Place(0, 0, "North");
            SteadyTurtle.Move();
            
            TablePosition actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Check_Left_Turns_90_Degree_Left_Without_Changing_Position()
        {
            Turtle SteadyTurtle = new Turtle();
            TablePosition expected = GetExpectedTablePosition(0, 0, Directions.West);

            SteadyTurtle.Place(0, 0, "North");
            SteadyTurtle.Left();

            TablePosition actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Check_Right_Turns_90_Degree_Right_Without_Changing_Position()
        {
            Turtle SteadyTurtle = new Turtle();
            TablePosition expected = GetExpectedTablePosition(0, 0, Directions.East);

            SteadyTurtle.Place(0, 0, "North");
            SteadyTurtle.Right();

            TablePosition actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Check_Place_Places_In_The_Specified_Positions_And_Direction()
        {
            Turtle SteadyTurtle = new Turtle();
            TablePosition expected = GetExpectedTablePosition(0, 0, Directions.North);

            TablePosition actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);

            expected = GetExpectedTablePosition(3, 4, Directions.East);
            SteadyTurtle.Place(3, 4, "East");            

            actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Check_Turtle_Is_Prevented_From_Falling_From_Edges()
        {
            Turtle SteadyTurtle = new Turtle();
            TablePosition expected = GetExpectedTablePosition(0, 0, Directions.North);

            TablePosition actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);

            expected = GetExpectedTablePosition(5, 3, Directions.East);

            SteadyTurtle.Place(5, 3, "East");
            actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(string.Empty, SteadyTurtle.Warning);

            SteadyTurtle.Move();

            actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(string.Empty, SteadyTurtle.Warning);

            expected = GetExpectedTablePosition(4, 0, Directions.South);
            SteadyTurtle.Place(4, 0, "South");

            actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(string.Empty, SteadyTurtle.Warning);

            SteadyTurtle.Move();

            actual = SteadyTurtle.Report();

            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(string.Empty, SteadyTurtle.Warning);
        }

        private TablePosition GetExpectedTablePosition(int x, int y, Directions direction)
        {
            TablePosition expected = new TablePosition();

            expected.XPosition = x;
            expected.YPosition = y;
            expected.FacingDirection = direction;

            return expected;
        }
    }
}
