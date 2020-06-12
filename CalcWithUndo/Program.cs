using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        
            UserInteraction(aMenu, aCalc, aCare);
            Environment.Exit(0);
        }

        private static void UserInteraction(UserInterface aMenu, Calculator aCalc, Caretaker aCare)
        {
            Console.Clear();

            if (aCalc.State != null)
            {
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
                    {
                        Console.WriteLine("Undoing last operation.");
                        aCalc.State = aCare.Undo();
                        if (aCare.Undo() == null)
                        {
                            Console.WriteLine("\nNothing to undo!\n");
                            Thread.Sleep(500);
                        }
                    }
                    break;
                case "Q":
                    Console.WriteLine("Leaving program.");
                    Environment.Exit(0);
                    break;

                
            }

            UserInteraction(aMenu, aCalc, aCare);
        }
    }
}
