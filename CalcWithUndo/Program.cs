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
        static UserInterface aMenu = new UserInterface();
        static Calculator aCalc = new Calculator();
        static Caretaker aCare = Caretaker.GetInstance();
        static void Main(string[] args)
        {
            
        
            UserInteraction();
            Environment.Exit(0);
        }

        private static void UserInteraction()
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
                case "R":
                    ResetAll();
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

            UserInteraction();
        }

        private static void ResetAll()
        {
            aCalc.Reset();
            aCare.Reset();
        }
    }
}
