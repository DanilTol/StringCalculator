using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

            var newDelimiter = Regex.Match(numbers, @"//(.*)\\n").Groups[1].Value;
            
            if (!string.IsNullOrEmpty(newDelimiter))
            {
                delimetersList.Add(newDelimiter[0]);
                var indexCut = numbers.IndexOf("\\n");
                numbers = numbers.Remove(0, indexCut + 2);
            }

            return numbers.Split(delimetersList.ToArray()).Select(strNum => Convert.ToInt32(strNum)).Sum();
        }
    }
}