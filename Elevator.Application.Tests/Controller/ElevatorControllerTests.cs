using ElevatorControlSystem.Application.Controller;
using ElevatorControlSystem.Entities;

namespace ElevatorControlSystem.Application.Tests.Controller
{
    [TestFixture]
    public class ElevatorControllerTests
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
        public void ElevatorController_Initialize_ShouldSetElevators()
        {
            var status = ElevatorController.Instance.GetElevatorsStatus();
            Assert.AreEqual(2, status.Count);
        }

        [Test]
        public async Task ElevatorController_AddRequest_ShouldAssignElevator()
        {
            ElevatorController.Instance.AddRequest(new ElevatorRequest(5, Direction.Up));
            await Task.Delay(60000); // 60 seconds
            var status = ElevatorController.Instance.GetElevatorsStatus();
            Assert.IsTrue(status.Any(e => e.CurrentFloor == 5));
        }
    }
}