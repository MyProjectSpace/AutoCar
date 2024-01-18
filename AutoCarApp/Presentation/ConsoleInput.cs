using AutoCarApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Presentation
{
    public class ConsoleInput : IInput
    {
        public char ReadKey()
        {
            return Console.ReadKey().KeyChar;
        }

        public string ReadString()
        {
            return Console.ReadLine();
        }
    }
}
