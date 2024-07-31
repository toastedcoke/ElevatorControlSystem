using ElevatorControlSystem.Application.Controller;
using ElevatorControlSystem.Entities;

namespace ElevatorControlSystem.Application.RequestHandling
{
    public class RequestGeneratorService : IRequestGeneratorService
    {
        private readonly int _maxFloor;
        private bool _generatingRequests;

        public RequestGeneratorService(int maxFloor)
        {
            _maxFloor = maxFloor;
            _generatingRequests = true;
        }

        public void StartGenerating()
        {
            Random rand = new Random();
            while (_generatingRequests)
            {
                int floor = rand.Next(0, _maxFloor + 1); // Adjusted to include ground floor (0)
                Direction direction = (Direction)rand.Next(0, 2);
                Console.WriteLine($"{direction} request on floor {floor}");
                ElevatorController.Instance.AddRequest(new ElevatorRequest(floor, direction));
                Thread.Sleep(rand.Next(5000, 15000)); // Generate a request every 5-15 seconds
            }
        }

        public void StopGenerating()
        {
            _generatingRequests = false;
        }
    }
}