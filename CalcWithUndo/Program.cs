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
            Calculator aCalc;
            // no, but like : while ((Console.ReadKey().Key  != ConsoleKey.L)) Console.Write(aMenu.Menu);
            Console.Write(aMenu.Menu);
            aMenu.InputString = Console.ReadKey().Key.ToString();
            switch (aMenu.InputString)
            {
                case "E":
                    Console.WriteLine(aMenu.EnterQuery());
                    string enteredEquation = Console.ReadLine();
                    if (aMenu.ValidateInput(enteredEquation))
                    {
                        
                        aCalc = new Calculator(enteredEquation);// run it through something like
                        // aMenu.ProcessString(aMenu.InputString);
                        // which will break the statement into its
                        // constituent parts

                        // (#,sign,#)

                        // and then do something like myCalc.Calculate(aMenu.Statement)
                        // where Statement is an array (?) containing the info needed to 
                        // describe a whole statement and its result
                    }

                    break;
            }
            Environment.Exit(0);
        }
    }
}
