

using ElevatorControlSystem.Application.Controller;
using ElevatorControlSystem.Application.RequestHandling;
using ElevatorControlSystem.Entities;

namespace ElevatorControlSystem.ConsoleApp.Tests
{
    [TestFixture]
    public class RequestGeneratorTests
    {
        [SetUp]
        public void SetUp()
        {
            var elevators = new List<Elevator>
            {
                new Elevator(1),
                new Elevator(2)
            };
            ElevatorController.Instance.Initialize(elevators);
        }

        [Test]
        public async Task RequestGenerator_ShouldGenerateRequests()
        {
            var generator = new RequestGeneratorService(10);
            var task = Task.Run(() => generator.StartGenerating());

            await Task.Delay(20000); // 20 seconds

            generator.StopGenerating();
            await task;
        }
    }
}
