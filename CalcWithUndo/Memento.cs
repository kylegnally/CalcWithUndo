using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    class Memento : IMemento
    {
        public Memento(string[] state)
        {
            this.GetState = state;
        }

        public string[] GetState { get; set; }

        public string GetEquation()
        {
            return GetState[0];
        }

        public string GetResult()
        {
            return GetState[1];
        }

        public string GetRunningTotal()
        {
            return GetState[2];
        }
    }
}
