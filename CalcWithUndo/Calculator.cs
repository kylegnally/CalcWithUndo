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


        //private int _anOperatorASCII;
        //private string _aSign;

        //private double _sum;
        //private double _difference;
        //private double _product;
        //private double _quotient;
        //private double _remainder;

        /*      Should this be a Singleton?     */

        //public Calculator()
        //{
        //    //if (_runningTotal != 0.00 || _runningTotal != null) _runningTotal = double.Parse(this.State.GetRunningTotal());
        //    Equation = "";
        //    Calculate(_userEntry);
        //}
        public Calculator()
        {
            _runningTotal = 0;
            _result = 0;
        }

        public void Calculate(string str)
        {

            State = null;
            // So, about what's going on here. What I'm doing is relying upon the 
            // .Compute() method of the DataTable class to parse the user's input
            // once I've validated with the regex pattern present in the UserInterface
            // class. This DataTable method is able to perform computations given string
            // input; essentially, it saves me from writing a parser and duplicating
            // existing functionality. 

            // Conveniently, the filter for the .Compute() method can be null. Also
            // conveniently, the operation appears to trim any whitespace automatically.
            // Since its output can convert to a double, I can simplify all of the code
            // for the math of the overall calculation problem down into one single,
            // simple, elegant call to a new object which the garbage collector will  destroy.
            _result = Convert.ToDouble(new DataTable().Compute(str, null));
            _runningTotal = _runningTotal + _result;
            _state = str + "|" + _result + "|" + _runningTotal;
            //sult = _result.ToString();
            RunningTotal = _runningTotal.ToString();
            SaveState(_state);
            Result = _result.ToString();
            // return _result;
        }

        public void Reset()
        {
            State = null;
            _runningTotal = 0;
            _result = 0;
            _state = "";
        }

        public void SaveState(string state)
        {
            State = new Memento(state);
        }
    }
}
