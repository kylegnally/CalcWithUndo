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
        //private double _leftTerm;
        //private double _rightTerm;
        private double _result;
        private double _runningTotal;
        public string[] Equation { get; set; }  

        //public string LeftTerm { get; set; }
        //public string RightTerm { get; set; }
        public string Result { get; set; }
        public string RunningTotal { get; set; }

        private string _userEntry;

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
            Calculate(_userEntry);
        }
        public Calculator(string userEntry)
        {
            _userEntry = userEntry;
            _runningTotal = 0;
            _state[0] = _userEntry;
            _state[1] = Calculate(_userEntry).ToString();
            _state[2] = RunningTotal.ToString();
        }

        private double Calculate(string str)
        {
            double result = Convert.ToDouble(new DataTable().Compute(str, null)); /* :) */
            RunningTotal += result;
            

            return result;
        }

        public IMemento Save()
        {
            return new Memento(this._state);
        }
    }
}
