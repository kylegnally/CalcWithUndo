using System;
using System.Text.RegularExpressions;

namespace CalcWithUndo
{
    class UserInterface
    {
        private string _inputString;
        private string _outputString;
        private string _menuString;
        private bool _firstRun;

        public string OutputString { get; set; }
        public string InputString { get; set; }
        public string Menu
        {
            get => _menuString;
            set => _menuString = value;
        }

        public UserInterface()
        {
            _firstRun = true;
            _inputString = "";
            _outputString = "";
            BuildMenu();
        }

        private void BuildMenu()
        {
            _menuString = "";
            _menuString = MainMenu();
            Menu = _menuString;
        }

        public string MainMenu()
        {
            string _justMenu = "Enter an equation and press the <Enter> key to perform a computation\n" +
                               "or enter any of the following options by themselves:\n" + 
                               "[U]ndo [C]lear [Q]uit [H]elp";
            return _justMenu;
        }

        public string EnterQuery()
        {
            string s = "\n\nEnter your equation: ";
            return s;
        }

        public bool ValidateInput(string s)
        {
            /*
             *
             *  See the design document for a breakdown on the workings of this monster.
             *
            */

            Regex pattern = new Regex(@"^((\s*[-+]?(\d+?(\.?\d{0,2})))(\s*[-+*\/]\s*)(\s*[-+]?(\d+?(\.?\d{0,2}))))$");
            if (pattern.IsMatch(s))
            {
                Console.WriteLine("Matched!");
                return true;
            }

            return false;
        }

        public string PrintState(string str)
        {
            string printableState;
            string[] deconstructedString = str.Split('|');
            printableState = "EQUATION:\t" + deconstructedString[0] + "\n" +
                             "RESULT:\t" + deconstructedString[1] + "\n" + 
                             "RUNNING TOTAL:\t" + deconstructedString[2];
            return printableState;
        }
    }
}
