using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    class Calculator
    {
        private string _state;
        private double _result;
        private double _runningTotal;
        public string RunningTotal { get; private set; }
        public string Result { get; private set; }

        public IMemento State { get; set; }
        public Calculator()
        {
            _runningTotal = 0;
            _result = 0;
        }

        public void Calculate(string str)
        {
            State = null;
            _result = Convert.ToDouble(new DataTable().Compute(str, null));
            _runningTotal = _runningTotal + _result;
            _state = str + "|" + _result + "|" + _runningTotal;
            RunningTotal = _runningTotal.ToString();
            SaveState(_state);
            Result = _result.ToString();
        }

        public void Reset()
        {
            State = null;
            _state = "";
            RunningTotal = "";
            _runningTotal = 0;
            Result = "0";
            _result = 0;
        }

        public void SaveState(string state)
        {
            State = new Memento(state);
        }
    }
}
