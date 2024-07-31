using ElevatorControlSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Entities.Tests
{
    [TestFixture]
    public class BuildingTests
    {
        [Test]
        public void Building_Initialization_ShouldCreateElevators()
        {
            var building = new Building(10, 4);
            Assert.AreEqual(4, building.Elevators.Count);
        }

        [Test]
        public void Building_Initialization_ShouldSetFloorsCorrectly()
        {
            var building = new Building(15, 4);
            Assert.AreEqual(15, building.Floors);
        }
    }
}
