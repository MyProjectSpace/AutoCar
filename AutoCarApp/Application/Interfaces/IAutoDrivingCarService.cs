using AutoCarApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Application.Interfaces
{
    public interface IAutoDrivingCarService
    {
        void SimulateAutoDrivingCar(int width, int height, Position initialPosition, string commands);
    }
}
