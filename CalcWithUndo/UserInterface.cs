using System;

namespace CalcWithUndo
{
    class UserInterface
    {
        private string _inputString;
        private string _outputString;
        private string _menuString;
        private bool _legalString;

        public string OutputString { get; set; }
        public bool IsLegalString { get; set; }

        public UserInterface()
        {
            _inputString = "";
            _outputString = "";
            _menuString = "";
            _legalString = false;
        }

        public string MakeMainMenu()
        {
            _menuString = "";
            _menuString += "\t\t*****Calculator with Undo Demo*****\n\n";
            _menuString += "\t\tPlease enter your equation below like:\n\n" +
                           "real-literal operation real-literal\n\n" +
                           "You may enter more than one 'operation real-literal'\n" +
                           "sequence wth or without whitespace, like '1 + 6 +77\n\n'" +
                           "The operators +*-/ are permitted. Yes, that's also a face.\n\n";
            return _menuString;
        }
    }
}
