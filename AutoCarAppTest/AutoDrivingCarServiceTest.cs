using AutoCarApp.Application;
using AutoCarApp.Application.Interfaces;
using AutoCarApp.Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarAppTest
{
    public class AutoDrivingCarServiceTest
    {
        [Fact]
        public void When_correct_input_given_output_x_Y_coordinates_and_direction()
        {
            int width = 5;
            int height = 5;
            var initialPosition = new Position(2, 2, "N");
            string commands = "FF";

            var consoleMock = new Mock<IOutput>();
            var autoDrivingCarService = new AutoDrivingCarService(consoleMock.Object);

            // Act
            autoDrivingCarService.SimulateAutoDrivingCar(width, height, initialPosition, commands);

            // Assert
            consoleMock.Verify(c => c.ShowMessage($"2 4 N"), Times.Once);
        }

    }
}
