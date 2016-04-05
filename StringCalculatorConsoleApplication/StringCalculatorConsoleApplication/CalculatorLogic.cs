using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculatorConsoleApplication
{
    public class CalculatorLogic
    {
        List<string> delimetersList = new List<string>
        {
            ",",
            "\n"
        }; 

        public int Add(string numbersString)
        {
            if (string.IsNullOrEmpty(numbersString))
                return 0;

            var newDelimiter = Regex.Match(numbersString, @"//(.*)\\n").Groups[1].Value;
            
            if (!string.IsNullOrEmpty(newDelimiter))
            {
                if (newDelimiter.IndexOf("[") > -1 && newDelimiter.IndexOf("]") > -1)
                {
                    var smthNew = newDelimiter.Substring(1).Remove(newDelimiter.Substring(1).Length - 1);

                    var newDelimitersArray = smthNew.Replace("][", " ").Split(' ');
                    delimetersList.AddRange(newDelimitersArray);
                }
                else
                {
                    delimetersList.Add(newDelimiter);
                }
                var indexCut = numbersString.IndexOf("\\n");
                numbersString = numbersString.Remove(0, indexCut + 2);
            }
            var numbers = numbersString.Split(delimetersList.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(strNum => Convert.ToInt32(strNum));
                
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