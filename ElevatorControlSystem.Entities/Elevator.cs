using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ElevatorControlSystem.Entities
{
    public enum Direction
    {
        Up,
        Down,
        Idle
    }

    public class Elevator
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsMoving { get; private set; }
        public Queue<int> Requests { get; set; }
        private int TopFloor { get; set; }

        public Elevator(int id, int startFloor = 0, int topFloor = 10) // Include top floor in the constructor
        {
            Id = id;
            CurrentFloor = startFloor;
            Direction = Direction.Idle;
            Requests = new Queue<int>();
            IsMoving = false;
            TopFloor = topFloor;
        }

        public void AddRequest(int floor)
        {
            if (floor >= 0 && floor <= TopFloor) // Check if the request is within valid floor range
            {
                Requests.Enqueue(floor);
                UpdateDirection();
            }
        }

        private void UpdateDirection()
        {
            if (Requests.Count == 0)
            {
                Direction = Direction.Idle;
            }
            else
            {
                Direction = Requests.Peek() > CurrentFloor ? Direction.Up : Direction.Down;
            }
        }

        public async Task MoveAsync()
        {
            while (Requests.Count > 0)
            {
                int targetFloor = Requests.Dequeue();
                while (CurrentFloor != targetFloor)
                {
                    IsMoving = true;

                    // Check if moving up would exceed the top floor
                    if (Direction == Direction.Up && CurrentFloor < TopFloor)
                    {
                        await Task.Delay(10000); // Move one floor
                        CurrentFloor++;
                    }
                    // Check if moving down would go below the ground floor
                    else if (Direction == Direction.Down && CurrentFloor > 0)
                    {
                        await Task.Delay(10000); // Move one floor down
                        CurrentFloor--;
                    }
                    else
                    {
                        break; // If we can't move in the desired direction, break the loop
                    }

                    Console.WriteLine($"Elevator {Id} is now on floor {CurrentFloor}");
                }
                IsMoving = false;
                Console.WriteLine($"Elevator {Id} has stopped on floor {CurrentFloor} to load/unload passengers");
                await Task.Delay(10000); // Load/Unload passengers
                UpdateDirection();
            }
        }
    }
}
