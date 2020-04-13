using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceRoller
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to DiceRoller");
            var UserInput = new UserInput();
            UserInput.StartApp();
            Console.WriteLine("Thank you for using Dice Roller!");
        }
    }
}