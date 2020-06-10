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
            //Regex pattern = new Regex("^\\s*([-+]?)(\\d+)(\\s*([-+*\\/])\\s*((\\s[-+])?([-+]?)\\d+)\\s*)$");
            //if (pattern.IsMatch(s))
            //{
                //Console.WriteLine("Matched!");
                return true;
                //IsLegalString = _legalString;
            //}

            //return false;
        }
    }
}
