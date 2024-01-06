﻿using AutoCarApp.Application.Interfaces;
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
        public void SimulateAutoDrivingCar(int width, int height, Position initialPosition, string commands)
        {
            var car = new AutoDrivingCar(width, height, initialPosition);
            car.Move(commands);

            // Display the final position and direction
            var (x, y, direction) = car.Position;
            Console.WriteLine($"{x} {y} {direction}");
        }
    }
}