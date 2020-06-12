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
            BuildMenu(_firstRun);
        }

        private void BuildMenu(bool firstRun)
        {
            _menuString = "";
            if (firstRun) _menuString += MakeWelcome();
            firstRun = false;
            _menuString += MainMenu();
        }

        private string MakeWelcome()
        {
            Console.Clear();
            string _welcomeString =  "\t\t*****Calculator with Undo Demo*****\n\n";
            _welcomeString += "\t\tPlease enter your equation at the prompt like:\n\n" +
                           "\t\treal-literal operation real-literal\n\n" +
                           "\t\t These may be entered or without whitespace, like '6 +77' or '34 + 3'.\n\n" +
                           "\t\tThe operators +*-/ are permitted, and decimal values are allowed.\n\n";
            return _welcomeString;
        }

        public string MainMenu()
        {
            string _justMenu = "\t\t********* Calculator Menu *********\n" +
                               "\t\t*                                 *\n" +
                               "\t\t*       [E]nter an equation       *\n" +
                               "\t\t*       [U]ndo prior calculation  *\n" +
                               "\t\t*       /*[D]o the next equation*/*\n" +      
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
