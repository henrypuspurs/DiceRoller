using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceRoller
{
    class Program
    {
        public static void Main(string[] args)
        {
            StartApp();
        }

        private static void StartApp()
        {
            int diceCount = 0;
            int diceType = 0;
            int bonus = 0;
            bool advantage = false;
            bool disadvantage = false;

            Console.WriteLine("Please enter dice type you would like to use as a number");
            var inputDice = Console.ReadLine();
            diceType = int.Parse(inputDice);

            if (diceType == 20)
            {
                Console.WriteLine("Please enter the number of dice you would like to roll");
                var inputCount = Console.ReadLine();
                diceCount = int.Parse(inputCount);
                if (diceCount > 2)
                {
                    Console.WriteLine("Why would you do that? Try again.");
                    StartApp();
                }
                if (diceCount == 2)
                {
                    Console.WriteLine("Press the A key for advantage, or the D key for disadvantage");
                    var rollType = Console.ReadKey();
                    Console.WriteLine(System.Environment.NewLine);
                    if (rollType.Key == ConsoleKey.A)
                    {
                        advantage = true;
                    }
                    else if (rollType.Key == ConsoleKey.D)
                    {
                        disadvantage = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        StartApp();
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter the number of dice you would like to roll");
                var inputCount = Console.ReadLine();
                diceCount = int.Parse(inputCount);
            }

            Console.WriteLine("Please enter a total bonus if applicable or 0");
            var inputBonus = Console.ReadLine();
            bonus = int.Parse(inputBonus);

            Console.WriteLine($"Rolling {diceCount}d{diceType} +{bonus}");


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

            int result = 0;
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
                StartApp();
            }
            else
            {
                Console.WriteLine("Thank you for using Dice Roller!");
            }
        }
    }
}