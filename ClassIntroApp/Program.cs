
namespace ClassIntroApp
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text.Json;
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText(".\\gamestatements.json");
            var allStatements = JsonSerializer.Deserialize<GameStatement[]>(jsonString);

            ChoiceMenu();

            foreach (GameStatement statement in allStatements)
            {
                Console.WriteLine($"{statement.Statement}");
            }
        }

        static void ChoiceMenu()
        {
            bool returnToMenu = true;

            do
            {
                Console.Clear();
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine("\t1. Two truths and a lie");
                Console.WriteLine("\t2. Johnny Bravo");
                Console.WriteLine("\t3. A little bit about the creator.");
                Console.WriteLine("\t4. Exit");
                Console.WriteLine("");
                Console.Write("Please enter your selection: ");
                var menuChoice = Console.ReadLine();

                if(int.TryParse(menuChoice, out int choice))
                {
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine("Going to play a game.");
                            break;

                        case 2:
                            Console.WriteLine("Display ascii art");
                            break;

                        case 3:
                            Console.WriteLine("Write Bio");
                            break;

                        case 4:
                            returnToMenu = false;
                            break;

                        default:
                            Console.WriteLine("Invalid Entry, try again!");
                            Thread.Sleep(500);
                            break;
                    }
                }

            } while (returnToMenu);

            
        }
    }
}
