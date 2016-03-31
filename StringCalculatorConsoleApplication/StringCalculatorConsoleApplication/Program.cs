using System;

namespace StringCalculatorConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var logic =  new CalculatorLogic();
            Console.WriteLine("Write data for sum\n");
            var input = Console.ReadLine();
            Console.WriteLine(logic.Add(input));
            Console.ReadLine();
        }
    }
}
