using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    class Memento : IMemento
    {
        private string[] _state;

        public Memento(string[] state)
        {
            this._state = state;
        }

        public string[] GetState()
        {
            return this._state;
        }
    }
}
