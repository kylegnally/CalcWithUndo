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
            string _justMenu = "\t\t********* Calculator Menu *********\n" +
                               "\t\t*                                 *\n" +
                               "\t\t*       [E]nter an equation       *\n" +
                               "\t\t*       [U]ndo prior calculation  *\n" +    
                               "\t\t*       [R]eset the calculator    *\n" +
                               "\t\t*                                 *\n" +
                               "\t\t*       [L]eave the program       *\n" +
                               "\t\t*       [?]elp                :)  *\n" +
                               "\t\t*                                 *\n" +
                               "\t\t***********************************\n";
            return _justMenu;
        }

        public string EnterQuery()
        {
            string s = "Enter your equation: ";
            return s;
        }

        public bool ValidateInput(string s)
        {
            /*  Broken down, here's what we're doing:
            
                ^\s*([-+]?)                         "Match any amount of whitespace followed by an optional sign"
                (\d+(\.\d{0,2}+)?)(\s*([-+*\/])\s*  "Match any digit, followed by an optional decimal value up to 
                                                    two digits long, followed by a required *, -, *, or / sign"
                
            //
            */
            //Regex pattern = new Regex("^\\s*([-+]?)(\\d+(\\.\\d{0,2}+)?)(\\s*([-+*\\/])\\s*((\\s[-+])?([-+]?)(\\d+(\\.\\d{0,2}+)?)\\s*))$");
            //if (pattern.IsMatch(s))
            //{
            //    Console.WriteLine("Matched!");
                return true;
            //}

            //return false;
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
