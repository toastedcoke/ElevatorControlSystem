using ElevatorControlSystem.Entities;
using ElevatorControlSystem.Application.RequestHandling;
using ElevatorControlSystem.Application.Controller;

namespace ElevatorControlSystem.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize the building and elevators
            int totalFloors = 10;
            int elevatorCount = 4;
            Building building = new Building(totalFloors, elevatorCount);
            ElevatorController.Instance.Initialize(building.Elevators);

            // Start generating requests
            RequestGeneratorService generator = new RequestGeneratorService(totalFloors);
            Task generatorTask = Task.Run(() => generator.StartGenerating());

            // Allow user to interact with the system
            Console.WriteLine("Press Enter to stop the application.");
            Console.ReadLine();

            // Stop generating requests
            generator.StopGenerating();
            await generatorTask;

            // Display the final status of elevators
            var elevatorStatuses = ElevatorController.Instance.GetElevatorsStatus();
            foreach (var status in elevatorStatuses)
            {
                Console.WriteLine($"Elevator {status.Id} is on floor {status.CurrentFloor}, moving: {status.IsMoving}, direction: {status.Direction}");
            }

            Console.WriteLine("Application stopped.");
        }
    }
}
