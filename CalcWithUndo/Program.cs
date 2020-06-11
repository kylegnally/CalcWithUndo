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
            Caretaker aCare;
            // no, but like : while ((Console.ReadKey().Key  != ConsoleKey.L)) Console.Write(aMenu.Menu);
            do
            {
                Console.Write(aMenu.Menu);
                aMenu.InputString = Console.ReadKey().Key.ToString();
                switch (aMenu.InputString)
                {
                    case "E":
                        Console.WriteLine(aMenu.EnterQuery());
                        string enteredEquation = Console.ReadLine();
                        if (aMenu.ValidateInput(enteredEquation))
                        {

                            aCalc = new Calculator(enteredEquation); // run it through something like
                            aCare = Caretaker.GetInstance(aCalc);

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
            } while (Console.ReadKey().Key != ConsoleKey.Q);


            Environment.Exit(0);
        }
    }
}
