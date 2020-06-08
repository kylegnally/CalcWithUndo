using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface aMenu = new UserInterface();

            Console.Write(aMenu.MakeMainMenu());
            Environment.Exit(0);
        }
    }
}
