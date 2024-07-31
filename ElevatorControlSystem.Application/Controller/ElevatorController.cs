using ElevatorControlSystem.Entities.DTOs;
using ElevatorControlSystem.Entities;
using AutoMapper;

namespace ElevatorControlSystem.Application.Controller
{
    public class ElevatorController : IElevatorController
    {
        private static readonly Lazy<ElevatorController> lazy = new Lazy<ElevatorController>(() => new ElevatorController());
        public static ElevatorController Instance => lazy.Value;

        private List<Elevator> Elevators { get; set; }
        private Queue<ElevatorRequest> Requests { get; set; }
        private readonly IMapper _mapper;

        public ElevatorController()
        {
            Requests = new Queue<ElevatorRequest>();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>()).CreateMapper();
        }

        public void Initialize(List<Elevator> elevators)
        {
            Elevators = elevators;
        }

        public void AddRequest(ElevatorRequest request)
        {
            Requests.Enqueue(request);
            AssignElevator();
        }

        public List<ElevatorDTO> GetElevatorsStatus()
        {
            return Elevators.Select(e => _mapper.Map<ElevatorDTO>(e)).ToList();
        }

        private void AssignElevator()
        {
            if (Requests.Count == 0)
                return;

            ElevatorRequest request = Requests.Dequeue();
            Elevator closestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in Elevators)
            {
                if (elevator.Direction == Direction.Idle ||
                    elevator.Direction == Direction.Up && request.Direction == Direction.Up && request.Floor >= elevator.CurrentFloor ||
                    elevator.Direction == Direction.Down && request.Direction == Direction.Down && request.Floor <= elevator.CurrentFloor)
                {
                    int distance = Math.Abs(elevator.CurrentFloor - request.Floor);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestElevator = elevator;
                    }
                }
            }

            if (closestElevator != null)
            {
                closestElevator.AddRequest(request.Floor);
                Task.Run(() => closestElevator.MoveAsync());
            }
            else
            {
                Requests.Enqueue(request); // Re-enqueue the request if no suitable elevator is found
            }
        }
    }
}
