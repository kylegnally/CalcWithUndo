using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalcWithUndo
{
    class Program
    {
        static void Main(string[] args)
        {
            aMenu = new UserInterface();
            Calculator aCalc = new Calculator();
            Caretaker aCare = new Caretaker();

        // no, but like : while ((Console.ReadKey().Key  != ConsoleKey.L)) Console.Write(aMenu.Menu);
        //Calculator aCalc;
        //Caretaker aCare;
        UserInteraction(aMenu);
            // while (Console.ReadKey().Key != ConsoleKey.Q);


            Environment.Exit(0);
        }

        private static void UserInteraction(UserInterface aMenu)
        {
            Console.Clear();

            if (aCalc != null)
            {
                Console.WriteLine("Calculation: " + "\t" + aCalc.Equation + "\n" +
                                  "Result:      " + "\t" + aCalc.Result + "\n" +
                                  "TOTAL TO NOW:" + "\t" + aCalc.RunningTotal + "\n\n");
            }
            Console.Write(aMenu.Menu);
            aMenu.InputString = Console.ReadKey().Key.ToString();
            switch (aMenu.InputString.ToUpper())
            {
                case "E":
                    Console.WriteLine(aMenu.EnterQuery());
                    string enteredEquation = Console.ReadLine();
                    if (aMenu.ValidateInput(enteredEquation))
                    {

                        aCalc = new Calculator(enteredEquation); // run it through something like
                        aCare = Caretaker.GetInstance(aCalc);
                    }
                    break;
                case "U":
                    Console.WriteLine("\n\nUNDOING LAST OPERATION\n\nCHANGING STATE FROM::" +
                                      "Calculation: " + "\t" + aCalc.Equation + "\n" +
                                      "Result:      " + "\t" + aCalc.Result + "\n" +
                                      "TOTAL TO NOW:" + "\t" + aCalc.RunningTotal + "\n\n");
                    aCalc.State = aCare.Undo();
                    Console.WriteLine("\nTO:\n\n" +
                                      "Calculation: " + "\t" + aCalc.Equation + "\n" +
                                      "Result:      " + "\t" + aCalc.Result + "\n" +
                                      "TOTAL TO NOW:" + "\t" + aCalc.RunningTotal + "\n\n + " +
                                      "UNDO COMPLETE.");
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;

                
            }

            UserInteraction(aMenu);
        }
    }
}
