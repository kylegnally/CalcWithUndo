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
            UserInterface aMenu = new UserInterface();
            Calculator aCalc = new Calculator();
            Caretaker aCare = Caretaker.GetInstance();
        // no, but like : while ((Console.ReadKey().Key  != ConsoleKey.L)) Console.Write(aMenu.Menu);
        //Calculator aCalc;
        //Caretaker aCare;
        UserInteraction(aMenu, aCalc, aCare);
            // while (Console.ReadKey().Key != ConsoleKey.Q);


            Environment.Exit(0);
        }

        private static void UserInteraction(UserInterface aMenu, Calculator aCalc, Caretaker aCare)
        {
            Console.Clear();

            if (aCalc.State != null)
            {
                //Console.WriteLine("TOTAL TO NOW:" + "\t" + aCalc.RunningTotal + "\n\n");
                Console.WriteLine(aMenu.PrintState(aCalc.State.GetState()));
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
                        aCalc.Calculate(enteredEquation); 
                        aCare.Add(aCalc.State);                    }
                    break;
                case "U":
                    Console.WriteLine("Undoing last operation.");
                    //Console.WriteLine("\n\nUNDOING LAST OPERATION\n\nCHANGING STATE FROM::" +
                    //                  "Calculation: " + "\t" + aCalc.Equation + "\n" +
                    //                  "Result:      " + "\t" + aCalc.Result + "\n" +
                    //                  "TOTAL TO NOW:" + "\t" + aCalc.RunningTotal + "\n\n");
                    aCalc.State = aCare.Undo();
                    //Console.WriteLine("\nTO:\n\n" +
                    //                  "Calculation: " + "\t" + aCalc.Equation + "\n" +
                    //                  "Result:      " + "\t" + aCalc.Result + "\n" +
                    //                  "TOTAL TO NOW:" + "\t" + aCalc.RunningTotal + "\n\n + " +
                    //                  "UNDO COMPLETE.");
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;

                
            }

            UserInteraction(aMenu, aCalc, aCare);
        }
    }
}
