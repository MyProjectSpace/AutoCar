using AutoCarApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Presentation
{
    public class ConsoleOutput : IOutput
    {
        public void ShowMessage(string message)
        {
            Console.Write(message);
        }

        public void ShowNewLineMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
