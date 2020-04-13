using System;
using System.Collections.Generic;
using System.Linq;

namespace DiceRoller
{
    class UserInput
    {
        int diceCount;
        int diceType;
        int bonus;
        bool advantage = false;
        bool disadvantage = false;
        string rollMessage = null;
        bool iSelect = false;
        public void StartApp()
        {
            Console.WriteLine("Press C for classic D&D Dice input or Press Enter for a guided input");
            var rollType = Console.ReadKey();
            Console.WriteLine(System.Environment.NewLine);
            if (rollType.Key == ConsoleKey.C)
            {
                iSelect = true;
                sUseri();
            }
            else
            {
                lUseri();
            }
        }

        public void sUseri()
        {
            Console.WriteLine("Please type the roll you would like to perform, for example - 2d6+4");
            var rollLine = Console.ReadLine();
            var diceLine = rollLine.Split(new Char[] { 'd', '+' }, StringSplitOptions.RemoveEmptyEntries);
            diceCount = int.Parse(diceLine[0]);
            diceType = int.Parse(diceLine[1]);
            if (diceLine.Length > 2)
            {
            bonus = int.Parse(diceLine[2]);
            }
            else
            {
                bonus = 0;
            }

            if (diceType == 20)
            {
                if (diceCount > 2)
                {
                    Console.WriteLine("Why would you do that? Try again.");
                    sUseri();
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
                        sUseri();
                    }
                }
            }

            if (advantage == true)
            {
                rollMessage = " at advantage";
            }
            if (disadvantage == true)
            {
                rollMessage = " at disadvantage";
            }
            Console.WriteLine($"Rolling {diceCount}d{diceType} +{bonus}{rollMessage}");

            var DiceTray = new DiceTray();
            DiceTray.Tray(diceCount, diceType, bonus, advantage, disadvantage, iSelect);
        }

        public void lUseri()
        {
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
                    lUseri();
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
                        lUseri();
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

            if (advantage == true)
            {
                rollMessage = " at advantage";
            }
            if (disadvantage == true)
            {
                rollMessage = " at disadvantage";
            }

            Console.WriteLine($"Rolling {diceCount}d{diceType} +{bonus}{rollMessage}");

            var DiceTray = new DiceTray();
            DiceTray.Tray(diceCount, diceType, bonus, advantage, disadvantage, iSelect);
        }
    }
}