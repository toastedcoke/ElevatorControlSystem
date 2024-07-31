using ElevatorControlSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Application.RequestHandling
{
    public interface IRequestGeneratorService
    {
        void StartGenerating();

        // Method to stop generating requests
        void StopGenerating();

        // Method to get generated requests
       // IEnumerable<ElevatorRequest> GetRequests();
    }
}
