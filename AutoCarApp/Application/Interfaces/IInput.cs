using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Application.Interfaces
{
    public interface IInput
    {
        char ReadKey();
        string ReadString();
    }
}
