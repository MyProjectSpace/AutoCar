using AutoCarApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Presentation
{
    public class ConsoleInput : IUserInput
    {
        public string GetValidCommands()
        {
            string command;
            bool isValid;
            do
            {
                Console.Write("Enter commands: ");
                command = Console.ReadLine();
                isValid = !string.IsNullOrEmpty(command) && command.Trim().All(c => c == 'R' || c == 'r' || c == 'L' || c == 'l' || c == 'F' || c == 'f');
                if (!isValid)
                {
                    Console.WriteLine("Invalid commands. Only allow commands are R/r/L/l/F/f. Please enter valid command");
                }
            } while (!isValid);
            return command;
        }

        public char GetValidDirection()
        {
            char value;
            bool isValid;
            do
            {
                Console.Write("Enter a direction: ");
                value = Console.ReadKey().KeyChar;
                isValid = IsValidDirection(value);
                if (!isValid)
                {
                    Console.WriteLine("Invalid direction. Please enter a valid direction");
                }
                Console.WriteLine();
            } while (!isValid);
            return value;
        }

        public int GetValidIntegerInput(string message)
        {
            int value;
            bool isValid;

            do
            {
                Console.Write(message);
                isValid = int.TryParse(Console.ReadLine(), out value);

                if (!isValid)
                {
                    Console.WriteLine("Invalid integer value. Please enter a valid integer.");
                }

            } while (!isValid);

            return value;
        }

        bool IsValidDirection(char direction)
        {
            if (direction == 'N' || direction == 'n' || direction == 'S' || direction == 's' || direction == 'E' || direction == 'e' || direction == 'W' || direction == 'w')
            {
                return true;
            }
            return false;
        }
    }

}
