
namespace ClassIntroApp
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            GameStatement statementOne = new GameStatement();
            statementOne.Statement = "I traveled around Japan for over two weeks.";
            statementOne.IsLie = false;


            Console.WriteLine($"{statementOne.Statement}");
        }
    }
}
