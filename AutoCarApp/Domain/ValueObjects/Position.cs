using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCarApp.Domain.ValueObjects
{
    public record Position(int X, int Y, string Direction);
}
