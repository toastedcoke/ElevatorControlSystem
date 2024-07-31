using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Entities.DTOs
{
    public class ElevatorDTO
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public bool IsMoving { get; set; }
        public string Direction { get; set; }
    }
}
