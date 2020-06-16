
namespace ClassIntroApp
{
    using System;
    using System.IO;
    using System.Text.Json;

    public class TruthsAndLies
    {
        public static void StartGame()
        {
            var allStatements = GetGameStatements();

            Console.Clear();
            Console.WriteLine("It's time to play two truths and a lie!");
            Console.WriteLine("=======================================\n");
            Console.WriteLine("Of the following statements, select which one you believe is the lie.\n");
            for (int x = 0; x < allStatements.Length; x++)
            {
                Console.WriteLine($"\t{x + 1}: {allStatements[x].Statement}");
            }

            Console.Write("\nPress any key to continue.");
            Console.ReadLine();
        }

        private static GameStatement[] GetGameStatements()
        {
            var jsonString = File.ReadAllText(".\\gamestatements.json");
            
            return JsonSerializer.Deserialize<GameStatement[]>(jsonString);
        }
    }
}
