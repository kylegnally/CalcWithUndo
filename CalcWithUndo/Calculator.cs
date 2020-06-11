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
        private string[] _state;
        private double _result;
        private double _runningTotal;
        private string _userEntry;

        public string Equation { get; set; }
        public string Result { get; set; }
        public string RunningTotal { get; set; }

        public IMemento State { get; set; }


        //private int _anOperatorASCII;
        //private string _aSign;

        //private double _sum;
        //private double _difference;
        //private double _product;
        //private double _quotient;
        //private double _remainder;

        /*      Should this be a Singleton?     */

        public Calculator()
        {
            _runningTotal = 0;
            Equation = "";
            Calculate(_userEntry);
        }
        public Calculator(string userEntry)
        {
            _userEntry = userEntry;
            Equation = _userEntry;
            _runningTotal = 0;
            _state = BuildState(userEntry);
            SaveState(_state);
        }

        private string[] BuildState(string entry)
        {
            _state = new string[3];
            _state[0] = entry;
            _state[1] = Calculate(entry).ToString();
            _state[2] = RunningTotal.ToString();
            return _state;
        }

        private double Calculate(string str)
        {
            double result = Convert.ToDouble(new DataTable().Compute(str, null)); /* :) */
            _result = result;
            Result = _result.ToString();
            RunningTotal += result;
            return result;
        }

        public IMemento SaveState(string[] state)
        {
            State = new Memento(state);
            return State;
        }
    }
}
