using AutoCarApp.Application.Interfaces;
using AutoCarApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Presentation
{
    public class AutoDrivingCarSimulator
    {
        private readonly IUserInput userInput;
        private readonly IAutoDrivingCarService autoDrivingCarService;
        private readonly IOutput console;

        public AutoDrivingCarSimulator(IUserInput userInput, IAutoDrivingCarService autoDrivingCarService, IOutput console)
        {
            this.userInput =  userInput ?? throw new ArgumentNullException(nameof(userInput));
            this.autoDrivingCarService = autoDrivingCarService ?? throw new ArgumentNullException(nameof(autoDrivingCarService));
            this.console = console ?? throw new ArgumentNullException(nameof(console));
        }

        public void RunSimulation()
        {
            console.ShowNewLineMessage("Enter width and height of the field in integer");
            int width = userInput.GetValidIntegerInput("Enter width: ");
            int height = userInput.GetValidIntegerInput("Enter height: ");
            console.ShowNewLineMessage("Enter initial positon in X and Y coordinates");
            int xCordinate = userInput.GetValidIntegerInput("Enter X cordinate: ");
            int yCordinate = userInput.GetValidIntegerInput("Enter Y cordinate: ");
            var direction = userInput.GetValidDirection();
            var commands = userInput.GetValidCommands();
            autoDrivingCarService.SimulateAutoDrivingCar(width, height, new Position(xCordinate, yCordinate, direction.ToString()), commands);
        }
    }
}
