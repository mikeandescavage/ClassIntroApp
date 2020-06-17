
namespace ClassIntroApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class BioWriter
    {
        private static string _BioTextPath { get; } = ".\\bio.txt";

        public static void WriteBio()
        {
            if (!File.Exists(_BioTextPath))
            {
                throw new FileNotFoundException($"Cannot find {_BioTextPath}");
            }

            var contents = File.ReadAllText(_BioTextPath);
            Console.Clear();
            Console.WriteLine(contents);
            Console.Write("\nPress any key to return to menu.");
            Console.ReadLine();
        }
    }
}
