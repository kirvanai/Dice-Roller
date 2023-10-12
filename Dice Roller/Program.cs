using System.IO;
using System;

namespace Dice_Roller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the dice simulator. Please enter the number of sides on the pair of dice you liked to roll:");
            int diceInput = 0;
            int diceValidator;
            bool validInput = false;
            while (validInput == false)
            {

                if (int.TryParse(Console.ReadLine(), out diceValidator) == true && diceValidator > 1)
                {
                    diceInput = diceValidator;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter valid whole number over 1.");
                    continue;
                }
            }

            if (diceInput == 6)
            {
                Console.WriteLine("You are now playing craps ");
                bool goOn = true;

                while (goOn == true)
                {
                    int dice1 = DiceGenerator(diceInput);
                    int dice2 = DiceGenerator(diceInput);
                    string output1 = SixSidedDice(dice1, dice2);
                    string output2 = Craps(dice1, dice2);
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    if (output1 != "")
                    {
                        Console.WriteLine(output1);
                    }
                    if (output2 != "")
                    {
                        Console.WriteLine(output2);
                    }

                    goOn = AskToContinue();
                }
            }
            else if (diceInput == 20)
            {
                Die20();
            }
            else
            {
                bool goOn = true;

                while (goOn == true)
                {
                    int dice1 = DiceGenerator(diceInput);
                    int dice2 = DiceGenerator(diceInput);
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    goOn = AskToContinue();
                }
            }

        }

        public static int DiceGenerator(int input)
        {
            Random dice = new Random();
            int diceOutput = dice.Next(1, input + 1);
            return diceOutput;
        }

        public static string SixSidedDice(int dice1, int dice2)
        {
            if (dice1 == 1 && dice2 == 1)
            {
                return "Snake Eyes!";
            }
            else if (dice1 == 1 && dice2 == 2)
            {
                return "Ace Deuce!";
            }
            else if (dice1 == 2 && dice2 == 1)
            {
                return "Ace Deuce!";
            }
            else if (dice1 == 6 && dice2 == 6)
            {
                return "Box Cars!";
            }
            else
            {
                return "";
            }

        }

        public static string Craps(int dice1, int dice2)
        {
            if (dice1 + dice2 == 2)
            {
                return "Craps!";
            }
            else if (dice1 + dice2 == 3)
            {
                return "Craps!";
            }
            else if (dice1 + dice2 == 12)
            {
                return "Craps!";
            }
            else if (dice1 + dice2 == 7)
            {
                return "You win craps!";
            }
            else if (dice1 + dice2 == 11)
            {
                return "You win craps!";
            }
            else
            {
                return "";
            }
        }
        public static void Die20()
        {
            Console.WriteLine("You are now a dual-wielding barbarian. Your weapons; two silver axes. You are bloodied and battered.");
            Console.WriteLine("Your entire party is down. You have one more chance to fell the two-headed dragon! Roll your dice and decide your fate!!!!");
            bool goOn = true;
            
            while (goOn == true)
            {
                int dice1 = DiceGenerator(20);
                int dice2 = DiceGenerator(20);
                if (dice1 == 20 && dice2 == 20)
                {
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    Console.WriteLine("DOUBLE CRIT! You perform an amazing feat of atheletics, jupming and severing both heads clean off!");
                    Console.WriteLine("The accolades of your prowess will be told for ages to come. You are a legendary hero!") ;
                    break;
                }
                else if (dice1 == 20 || dice2 == 20)
                {
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    Console.WriteLine("Critical hit! You manage to lop off one head with one axe, doing just enough damage to fell the dragon.");
                    Console.WriteLine("Your party is saved! Nice work!");
                    break;
                }
                else if (dice1 + dice2 > 30)
                {
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    Console.WriteLine("You give it your all and land a couple solid hits on the dragon. However it is not enough.");
                    Console.WriteLine("You are scorched by the dragon's flames. Your party is wiped...");
                    goOn = AskToContinueDnD();
                }

                else if(dice1 + dice2 <= 21 && dice1 == 1 || dice2 == 1)
                {
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    Console.WriteLine("You swing and wiff it. Laying flat on your back, you get eaten by one of the dragon heads. Your party is wiped!");
                    goOn = AskToContinueDnD();
                }

                else if (dice1 == 1 && dice2 == 1)
                {
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    Console.WriteLine("You swing and miss both attacks so pathetically, that I have choosen to end the game without any more chances loser! Tough luck!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Dice 1: {dice1}");
                    Console.WriteLine($"Dice 2: {dice2}");
                    Console.WriteLine("You give it your all and land a weak hit or two on the dragon. However it is not enough.");
                    Console.WriteLine("You are downed by a vicious bite.Your party is wiped...");
                    goOn = AskToContinueDnD();

                }
            }


        }
        public static bool AskToContinue()
        {
            Console.WriteLine("Roll again? y/n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Reponse. y/n?");
                return AskToContinue();
            }
        }

        public static bool AskToContinueDnD()
        {
            Console.WriteLine("You died! Try again? y/n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Reponse. y/n?");
                return AskToContinue();
            }
        }

    }
}