
namespace ClassIntroApp
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading;

    public class TruthsAndLies
    {
        private static string _GameFileLocation = ".\\gamestatements.json";

        public static void StartGame()
        {
            var allStatements = GetGameStatements();
            bool validEntry = false;

            do
            {

                Console.Clear();
                Console.WriteLine("It's time to play two truths and a lie!");
                Console.WriteLine("=======================================\n");
                Console.WriteLine("Of the following statements, select which one you believe is the lie.\n");

                for (int x = 0; x < allStatements.Length; x++)
                {
                    Console.WriteLine($"\t{x + 1}: {allStatements[x].Statement}");
                }

                Console.Write("\nChoose your option [1-3]");

                var answer = Console.ReadLine();

                if (int.TryParse(answer, out int result) && (result > 0 && result <= 3))
                {
                    validEntry = true;

                    if (allStatements[result - 1].IsLie)
                    {
                        Console.WriteLine("Congrats! You guessed correctly!");
                        Console.WriteLine("\nPress any key to return to main menu.");
                        Console.ReadLine();
                    }
                    else
                    {
                        validEntry = false;
                        Console.WriteLine("Sorry, that is actually a truth.  Try again!");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, invalid entry.  Please try again.");
                    Thread.Sleep(1000);
                }

            } while (!validEntry);

        }

        private static GameStatement[] GetGameStatements()
        {
            if (!File.Exists(_GameFileLocation))
            { 
                throw new FileNotFoundException($"{_GameFileLocation} is not found.");
            }

            var jsonString = File.ReadAllText(_GameFileLocation);

            try
            {
                var results = JsonSerializer.Deserialize<GameStatement[]>(jsonString);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
