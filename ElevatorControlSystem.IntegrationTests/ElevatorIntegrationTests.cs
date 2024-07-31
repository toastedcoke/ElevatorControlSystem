using ElevatorControlSystem.Application.Controller;
using ElevatorControlSystem.Entities;

namespace ElevatorControlSystem.IntegrationTests
{
    public class ElevatorIntegrationTests
    {
        [SetUp]
        public void SetUp()
        {
            var building = new Building(10, 4);
            ElevatorController.Instance.Initialize(building.Elevators);
        }

        [Test]
        public async Task ElevatorIntegration_ShouldProcessRequestsCorrectly()
        {
            ElevatorController.Instance.AddRequest(new ElevatorRequest(5, Direction.Up));
            await Task.Delay(55000); // 55 seconds

            var status = ElevatorController.Instance.GetElevatorsStatus();
            Assert.IsTrue(status.Any(e => e.CurrentFloor == 5));
        }

        [Test]
        public async Task ElevatorIntegration_ShouldHandleMultipleRequests()
        {
            ElevatorController.Instance.AddRequest(new ElevatorRequest(3, Direction.Up));
            ElevatorController.Instance.AddRequest(new ElevatorRequest(7, Direction.Down));
            await Task.Delay(75000); // 75 seconds

            var status = ElevatorController.Instance.GetElevatorsStatus();
            Assert.IsTrue(status.Any(e => e.CurrentFloor == 3 || e.CurrentFloor == 7));
        }
    }
}