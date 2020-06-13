using System;
using System.Text.RegularExpressions;

namespace CalcWithUndo
{
    class UserInterface
    {
        private string _menuString;
        private bool _firstRun;

        public string InputString { get; set; }
        public string Menu
        {
            get => _menuString;
            set => _menuString = value;
        }

        /// <summary>
        /// Constructor for a user interface.
        /// </summary>
        public UserInterface()
        {
            _firstRun = true;
            BuildMenu();
        }

        /// <summary>
        /// Method to build the menu.
        /// </summary>
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
                               "[E]nter [U]ndo [C]lear [Q]uit [H]elp\n\n";
            return _justMenu;
        }

        /// <summary>
        /// Prompt for the user to enter a query (equation).
        /// </summary>
        /// <returns></returns>
        public string EnterQuery()
        {
            string s = "\n\nEnter your equation: ";
            return s;
        }

        /// <summary>
        /// Input validation via regex.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>bool</returns>
        public bool ValidateInput(string s)
        {
            /*
             *
             *  See the design document for a breakdown on the workings of this monster.
             *
            */

            Regex pattern = new Regex("^((\\s*[-+]?(\\d*?(\\.?\\d{0,2})))(\\s*[-+*\\/]\\s*)(\\s*[-+]?(\\d*?(\\.?\\d{0,2}))))$");
            if (pattern.IsMatch(s))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Method to print the state of the calculator via the string provided from a Memento.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string PrintState(string str)
        {
            string printableState;
            string[] deconstructedString = str.Split('|');
            printableState = "EQUATION:\t" + deconstructedString[0] + "\n" +
                             "RESULT:\t\t" + deconstructedString[1] + "\n" + 
                             "RUNNING TOTAL:\t" + deconstructedString[2];
            return printableState;
        }
    }
}
