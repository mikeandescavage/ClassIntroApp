
namespace ClassIntroApp
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = File.ReadAllText(".\\gamestatements.json");
            var allStatements = JsonSerializer.Deserialize<GameStatement[]>(jsonString);

            foreach (GameStatement statement in allStatements)
            {
                Console.WriteLine($"{statement.Statement}");
            }
        }
    }
}
