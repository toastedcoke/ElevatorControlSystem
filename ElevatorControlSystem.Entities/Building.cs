using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Entities
{
    public class Building
    {
        public int Floors { get; private set; }
        public List<Elevator> Elevators { get; private set; }

        public Building(int floors, int elevatorCount)
        {
            Floors = floors;
            Elevators = new List<Elevator>();
            for (int i = 0; i < elevatorCount; i++)
            {
                Elevators.Add(new Elevator(i + 1));
            }
        }
    }
}
