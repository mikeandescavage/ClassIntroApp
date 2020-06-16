
namespace ClassIntroApp
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading;

    public class TruthsAndLies
    {
        private static string _GameFileLocation { get; } = ".\\gamestatements.json";
        private static GameStatement[] _AllStatements { get; } = GetGameStatements();

        public static void StartGame()
        {
            bool validEntry = false;

            do
            {
                DisplayGameTitle();
                ShowGameChoices();

                Console.Write($"\nChoose your option [1-{_AllStatements.Length}]");

                string answer = Console.ReadLine();

                if (IsValidInput(answer, _AllStatements.Length, out int result))
                {
                    validEntry = true;
                    if (_AllStatements[result - 1].IsLie)
                    {
                        Console.WriteLine("Congrats! You guessed correctly!");
                        Console.WriteLine("\nPress any key to return to continue.");
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

        private static void DisplayGameTitle()
        {
            Console.Clear();
            Console.WriteLine("It's time to play two truths and a lie!");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Of the following statements, select which one you believe is the lie.\n");
        }

        private static void ShowGameChoices()
        {
            for (int x = 0; x < _AllStatements.Length; x++)
            {
                Console.WriteLine($"\t{x + 1}: {_AllStatements[x].Statement}");
            }
        }

        private static bool IsValidInput(string input, int maxRange, out int num)
        {
            num = -1;

            if (int.TryParse(input, out int result) && (result > 0 && result <= maxRange))
            {
                num = result;
                return true;
            }

            return false;
        }
    }
}
