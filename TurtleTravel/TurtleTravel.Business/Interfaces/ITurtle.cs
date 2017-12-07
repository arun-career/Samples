using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTravel.Business.Interfaces
{
    public interface ITurtle
    {
        string Warning { get; set; }

        void Place(int X, int Y, string Facing);

        void Move();

        void Left();

        void Right();

        TablePosition Report();
    }
}
