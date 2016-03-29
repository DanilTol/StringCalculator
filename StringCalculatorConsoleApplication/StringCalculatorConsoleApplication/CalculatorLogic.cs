using System;
using System.Linq;

namespace StringCalculatorConsoleApplication
{
    public class CalculatorLogic
    {
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            return numbers.Split(',').Select(strNum => Convert.ToInt32(strNum)).Sum();
        }
    }
}