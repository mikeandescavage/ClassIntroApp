
namespace ClassIntroApp
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Text.Json;
    using System.Threading;

    public class TruthsAndLies
    {
        #region Private Members

        private static string _GameFileLocation { get; } = ".\\gamestatements.json";
        private static GameStatement[] _AllStatements { get; } = GetGameStatements();

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public static void StartGame()
        {
            bool validEntry = false;

            do
            {
                DisplayGameTitle();

                // get three new statements each time!
                GameStatement[] theThreeStatements = GetTwoTruthsAndALie();
                ShowGameChoices(theThreeStatements);

                Console.Write($"\nChoose your option [1-{theThreeStatements.Length}]");

                string answer = Console.ReadLine();

                if (IsValidInput(answer, theThreeStatements.Length, out int result))
                {
                    validEntry = true;
                    if (theThreeStatements[result - 1].IsLie)
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

        #endregion

        #region Private Methods

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

        private static void ShowGameChoices(GameStatement[] choices)
        {
            for (int x = 0; x < choices.Length; x++)
            {
                Console.WriteLine($"\t{x + 1}: {choices[x].Statement}");
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

        private static GameStatement[] GetTwoTruthsAndALie()
        {
            Random random = new Random();

            var allLies = _AllStatements.Where(x => x.IsLie == true);
            var allTruths = _AllStatements.Where(x => x.IsLie == false);

            var theLie = allLies.ElementAt(random.Next(0, allLies.Count()));
            var truths = allTruths.OrderBy(x => random.Next()).ToArray();

            GameStatement[] retVal = { theLie, truths[0], truths[1] };

            return retVal.OrderBy(x => random.Next()).ToArray();
        }

        #endregion
    }
}
