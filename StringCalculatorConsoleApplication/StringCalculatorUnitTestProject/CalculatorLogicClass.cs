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
            public void EmptyInput_OutputZero()
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
            public void OneArgInput_OutputInputArg()
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
            public void TwoArgsInput_OutputSumOfArgs()
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
            public void FourArgsInput_OutputSumOfArgs()
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
            public void ArgsNewLineDelimeter_OutputSumOfArgs()
            {
                //arrange
                string input = "1\n2,3,4";
                var logic = new CalculatorLogic();
                //act
                int ans = logic.Add(input);
                //assert
                Assert.AreEqual(10, ans, "New line delimeter");
            }
        }
    }
}
