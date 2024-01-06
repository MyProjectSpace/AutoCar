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

        public AutoDrivingCarSimulator(IUserInput userInput, IAutoDrivingCarService autoDrivingCarService)
        {
            this.userInput =  userInput ?? throw new ArgumentNullException(nameof(userInput));
            this.autoDrivingCarService = autoDrivingCarService ?? throw new ArgumentNullException(nameof(autoDrivingCarService));
        }

        public void RunSimulation()
        {
            Console.WriteLine("Enter width and height of the field in integer");
            int width = userInput.GetValidIntegerInput("Enter width: ");
            int height = userInput.GetValidIntegerInput("Enter height: ");
            Console.WriteLine("Enter initial positon in X and Y coordinates");
            int xCordinate = userInput.GetValidIntegerInput("Enter X cordinate: ");
            int yCordinate = userInput.GetValidIntegerInput("Enter Y cordinate: ");
            var direction = userInput.GetValidDirection();
            var commands = userInput.GetValidCommands();
            autoDrivingCarService.SimulateAutoDrivingCar(width, height, new Position(xCordinate, yCordinate, direction.ToString()), commands);
        }
    }
}
