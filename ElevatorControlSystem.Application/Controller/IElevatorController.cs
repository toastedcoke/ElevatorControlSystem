using ElevatorControlSystem.Entities;
using ElevatorControlSystem.Entities.DTOs;

namespace ElevatorControlSystem.Application.Controller
{
    public interface IElevatorController
    {
        void Initialize(List<Elevator> elevators);
        void AddRequest(ElevatorRequest request);
        List<ElevatorDTO> GetElevatorsStatus();
    }
}
