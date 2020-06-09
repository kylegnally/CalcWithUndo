using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface aMenu = new UserInterface();
            // no, but like : while ((Console.ReadKey().Key  != ConsoleKey.L)) Console.Write(aMenu.Menu);
            Console.Write(aMenu.Menu);
            aMenu.InputString = Console.ReadKey().Key.ToString();
            switch (aMenu.InputString)
            {
                case "E":
                    Console.WriteLine(aMenu.EnterQuery);
                    Regex pattern = new Regex("^\\s*([-+]?)(\\d+)(\\s*([-+*\\/])\\s*((\\s[-+])?([-+]?)\\d+)\\s*)$");
                    break;
            }
            Environment.Exit(0);
        }
    }
}
