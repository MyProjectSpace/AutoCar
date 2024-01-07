using AutoCarApp.Domain.Entities;
using AutoCarApp.Domain.ValueObjects;

namespace AutoCarAppTest
{
    public class AutoDrivingCarTest
    {
        [Theory]
        [InlineData(2, 2, 0, 0, "N", "F", 0, 1, "N")]
        [InlineData(3, 3, 1, 1, "N", "L", 1, 1, "W")]
        [InlineData(3, 3, 1, 1, "N", "R", 1, 1, "E")]
        public void When_correct_command_is_given_car_moved_to_correct_position(
            int width, int height, int initialX, int initialY, string initialDirection,
            string command, int expectedX, int expectedY, string expectedDirection)
        {
            var initialPosition = new Position(initialX, initialY, initialDirection);
            var autoDrivingCar = new AutoDrivingCar(width, height, initialPosition);
            autoDrivingCar.Move(command);
            Assert.Equal(new Position(expectedX, expectedY, expectedDirection), autoDrivingCar.Position);

        }

        [Theory]
        //When move out of boundries.
        [InlineData(5, 5, 0, 0, "N", "FFFFFFF", 0, 5, "IGNORED")]
        // When invalid command is given.
        [InlineData(5, 5, 0, 0, "N", "A", 0, 0, "N")]
        public void When_incorrect_command_is_given_car_ignore_the_command(
           int width, int height, int initialX, int initialY, string initialDirection,
           string command, int expectedX, int expectedY, string expectedDirection)
        {
            var initialPosition = new Position(initialX, initialY, initialDirection);
            var autoDrivingCar = new AutoDrivingCar(width, height, initialPosition);
            autoDrivingCar.Move(command);
            Assert.Equal(new Position(expectedX, expectedY, expectedDirection), autoDrivingCar.Position);

        }
    }
}