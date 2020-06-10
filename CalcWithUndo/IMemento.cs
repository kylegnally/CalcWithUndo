using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    public interface IMemento
    {
        string[] GetState();
        string GetResult();

        string GetEquation();
        string GetRunningTotal();
    }
}
