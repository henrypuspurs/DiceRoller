using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceRoller
{
    class DiceTray
    {
        public void Tray(int diceCount, int diceType, int bonus, bool advantage, bool disadvantage, bool iSelect)
        {
            int diceCounter = diceCount;
            List<int> rollList = new List<int>();

            while (diceCounter >= 1)
            {
                Random r = new Random();
                int Roll = r.Next(1, diceType + 1);
                rollList.Add(Roll);
                if (Roll == diceType)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (Roll == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(Roll);
                if (diceType == 20 && Roll == 1)
                {
                    Console.WriteLine("CRITICAL FAIL");
                }
                if (diceType == 20 && Roll == 20)
                {
                    Console.WriteLine("CRITICAL SUCCESS");
                }
                diceCounter = diceCounter - 1;
                Console.ResetColor();
            }

            int result;
            if (advantage == true)
            {
                result = rollList.Max() + bonus;
            }
            else if (disadvantage == true)
            {
                result = rollList.Min() + bonus;
            }
            else
            {
                result = rollList.Sum() + bonus;
            }
            Console.WriteLine($"Total:{result}");
            Console.WriteLine("Press any key to roll again or q to quit.");
            var restart = Console.ReadKey();
            Console.WriteLine(System.Environment.NewLine);
            if (restart.Key != ConsoleKey.Q)
            {
                if (iSelect == true)
                {
                    var UserInput = new UserInput();
                    UserInput.sUseri();
                }
                else
                {
                    var UserInput = new UserInput();
                    UserInput.lUseri();
                }
            }
        }
    }
}