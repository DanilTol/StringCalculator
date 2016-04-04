using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorConsoleApplication;

namespace StringCalculatorUnitTestProject
{
    [TestClass]
    public class CalculatorLogicClass
    {
        [TestClass]
        public class AddMethod
        {
            [TestMethod]
            public void Add_EmptyInput_OutputZero()
            {
                //arrange
                string input = string.Empty;
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(0,ans,"Input is empty string");
            }

            [TestMethod]
            public void Add_OneArgInput_OutputInputArg()
            {
                //arrange
                string input = "2";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(2, ans, "Input one arg");
            }

            [TestMethod]
            public void Add_TwoArgsInput_OutputSumOfArgs()
            {
                //arrange
                string input = "1,2";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(3, ans, "Input two arg");
            }

            [TestMethod]
            public void Add_FourArgsInput_OutputSumOfArgs()
            {
                //arrange
                string input = "1,2,3,4";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(10, ans, "Input two arg");
            }

            [TestMethod]
            public void Add_ArgsNewLineDelimiter_OutputSumOfArgs()
            {
                //arrange
                string input = "1\n2,3,4";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(10, ans, "New line delimiter");
            }

            [TestMethod]
            public void Add_DifferentDelimiter_OutputSumOfArgs()
            {
                //arrange
                string input = "//;\\n1;2";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(3, ans, "; delimiter");
            }

            [TestMethod]
            [ExpectedException(typeof(NegativeNumbersExeption),"-1")]
            public void Add_OneNegativeArg_Catch_Exception()
            {
                //arrange
                string input = "//;\\n-1;2";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
            }

            [TestMethod]
            [ExpectedException(typeof(NegativeNumbersExeption), "-1")]
            public void Add_TwoNegativeArg_Catch_Exception()
            {
                //arrange
                string input = "//;\\n-1;-2";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
            }

            [TestMethod]
            public void Add_NumberBigger1000_OutputOneArg()
            {
                //arrange
                string input = "1000,2";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(2, ans, "Bigger than 1000");
            }

        }
    }
}
