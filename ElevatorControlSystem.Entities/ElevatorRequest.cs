using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Entities
{
    public class ElevatorRequest
    {
        public int Floor { get; private set; }
        public Direction Direction { get;  set; }

        public ElevatorRequest(int floor, Direction direction)
        {
            Floor = floor;
            Direction = direction;
        }
    }
}
