using System;
using System.Data;

namespace CalcWithUndo
{
    class Calculator
    {
        // backing fields for properties
        private string _state;
        private double _result;
        private double _runningTotal;

        // properties
        public string RunningTotal { get; private set; }
        public string Result { get; private set; }

        public IMemento State { get; set; }

        /// <summary>
        /// Calculator class contructor.
        /// </summary>
        public Calculator()
        {
            _runningTotal = 0;
            _result = 0;
        }

        /// <summary>
        /// Calculate method. Takes a string and sets the field _result equal to the result of te Compute method of
        /// the Datatable class, cast to a double. 
        /// </summary>
        /// <param name="str"></param>
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

        /// <summary>
        /// Reset method. Sets Calculator to its initial state when called.
        /// </summary>
        public void Reset()
        {
            State = null;
            _state = "";
            RunningTotal = "";
            _runningTotal = 0;
            Result = "0";
            _result = 0;
        }

        /// <summary>
        /// Saves the calculator's state to a Memento.
        /// </summary>
        /// <param name="state"></param>
        public void SaveState(string state)
        {
            State = new Memento(state);
        }
    }
}
