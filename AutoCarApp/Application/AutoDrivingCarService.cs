using AutoCarApp.Application.Interfaces;
using AutoCarApp.Domain.Entities;
using AutoCarApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Application
{
    public class AutoDrivingCarService : IAutoDrivingCarService
    {
        private readonly IOutput console;

        public AutoDrivingCarService(IOutput consoleOutput)
        {
            this.console = consoleOutput;
        }

        public void SimulateAutoDrivingCar(int width, int height, Position initialPosition, string commands)
        {
            var car = new AutoDrivingCar(width, height, initialPosition);
            car.Move(commands);

            // Display the final position and direction
            var (x, y, direction) = car.Position;
            console.ShowNewLineMessage(string.Empty);
            console.ShowNewLineMessage("## Sample Output");
            console.ShowNewLineMessage("Based on the sample input above, the output would be:");
            console.ShowNewLineMessage($"{x} {y} {direction.ToUpper()}");
        }
    }
}
