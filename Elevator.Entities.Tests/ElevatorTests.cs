namespace ElevatorControlSystem.Entities.Tests
{
    [TestFixture]
    public class ElevatorTests
    {
        [Test]
        public void Elevator_InitialState_ShouldBeIdle()
        {
            var elevator = new Elevator(1);
            Assert.AreEqual(Direction.Idle, elevator.Direction);
            Assert.IsFalse(elevator.IsMoving);
        }

        [Test]
        public async Task Elevator_MoveAsync_ShouldMoveCorrectly()
        {
            var elevator = new Elevator(1, 0, 10);
            elevator.AddRequest(5);
            await elevator.MoveAsync();
            Assert.AreEqual(5, elevator.CurrentFloor);
            Assert.IsFalse(elevator.IsMoving);
        }

        [Test]
        public void Elevator_AddRequest_ShouldUpdateDirection()
        {
            var elevator = new Elevator(1, 0, 10);
            elevator.AddRequest(7);
            Assert.AreEqual(Direction.Up, elevator.Direction);
        }

        [Test]
        public void Elevator_RequestOutsideFloorRange_ShouldNotBeAdded()
        {
            var elevator = new Elevator(1, 0, 10);
            elevator.AddRequest(-1); // Invalid request
            elevator.AddRequest(11); // Invalid request
            Assert.IsEmpty(elevator.Requests);
        }
    }
}
