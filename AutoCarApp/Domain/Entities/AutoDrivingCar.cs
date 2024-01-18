using AutoCarApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Domain.Entities
{
    public class AutoDrivingCar
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; private set; }

        public AutoDrivingCar(int width, int height, Position position)
        {
            Width = width;
            Height = height;
            Position = position;
        }

        public void Move(string commands)
        {
            commands = commands.ToUpperInvariant();
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        MoveForward();
                        break;
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                }
                CheckBoundaries();
            }
        }
        private void MoveForward()
        {
            var (x, y, direction) = Position;
            Position = direction.ToUpperInvariant() switch
            {
                "N" => new Position(x, y + 1, direction),
                "E" => new Position(x + 1, y, direction),
                "S" => new Position(x, y - 1, direction),
                "W" => new Position(x - 1, y, direction),
                _ => Position
            };
        }

        private void RotateLeft()
        {
            var (x, y, direction) = Position;
            Position = direction.ToUpperInvariant() switch
            {
                "N" => new Position(x, y, "W"),
                "E" => new Position(x, y, "N"),
                "S" => new Position(x, y, "E"),
                "W" => new Position(x, y, "S"),
                _ => Position
            };
        }

        private void RotateRight()
        {
            var (x, y, direction) = Position;
            Position = direction.ToUpperInvariant() switch
            {
                "N" => new Position(x, y, "E"),
                "E" => new Position(x, y, "S"),
                "S" => new Position(x, y, "W"),
                "W" => new Position(x, y, "N"),
                _ => Position
            };
        }

        private void CheckBoundaries()
        {
            var (x, y, _) = Position;
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                // Ignore the command if it goes out of boundaries
                Position = new Position(x, y, "IGNORED");
            }
        }
    }
}
