using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorConsoleApplication
{
    public class CalculatorLogic
    {
        List<char> delimetersList = new List<char>
        {
            ',',
            '\n'
        }; 

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            return numbers.Split(delimetersList.ToArray()).Select(strNum => Convert.ToInt32(strNum)).Sum();
        }
    }
}