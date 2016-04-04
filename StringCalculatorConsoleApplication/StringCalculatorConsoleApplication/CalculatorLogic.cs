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

        public int Add(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString))
                return 0;

            var newDelimiter = Regex.Match(numbersString, @"//(.*)\\n").Groups[1].Value;
            
            if (!string.IsNullOrEmpty(newDelimiter))
            {
                delimetersList.Add(newDelimiter[0]);
                var indexCut = numbersString.IndexOf("\\n");
                numbersString = numbersString.Remove(0, indexCut + 2);
            }
            var numbers = numbersString.Split(delimetersList.ToArray()).Select(strNum => Convert.ToInt32(strNum));
                
            var negativeNumbers = numbers.Where(i => i < 0).ToArray();

            var negativeString = string.Join(".", negativeNumbers.Select(value => value));

            if (!string.IsNullOrEmpty(negativeString))
            {
                throw new NegativeNumbersExeption(negativeString);
            }
            
            return numbers.Select(value => value > 999 ? 0 : value).Sum();
        }
    }

    public class NegativeNumbersExeption : Exception
    {
        private string mess;

        public override string Message => mess;

        public NegativeNumbersExeption(string message)
        {
            mess = message;
        }
    }
}