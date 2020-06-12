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

        private string _equation;
        private string _result;
        private string _runningTotal;


        public Memento(string[] state)
        {
            // do I need these?
            this._equation = state[0];
            this._result = state[1];
            this._runningTotal = state[2];
        }

        public string[] GetState()
        {
            return this._state;
        }

        //public string GetEquation()
        //{
        //    return _state[0];
        //}

        //public string GetResult()
        //{
        //    return _state[1];
        //}

        //public string GetRunningTotal()
        //{
        //    return _state[2];
        //}
    }
}
