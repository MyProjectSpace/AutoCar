using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Application.Interfaces
{
    public interface IOutput
    {
        void ShowNewLineMessage(string message);
        void ShowMessage(string message);
    }
}
