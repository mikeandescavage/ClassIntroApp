
namespace ClassIntroApp
{
    using System;
    using System.Threading;

    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ChoiceMenu();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void ChoiceMenu()
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
                            TruthsAndLies.StartGame();
                            break;

                        case 2:
                            JohnnyBravo.DrawMe();
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
