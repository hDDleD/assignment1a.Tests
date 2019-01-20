using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1a;
using Xunit;
using Xunit.Abstractions;

namespace Assignment1a.Tests
{
    public class FibonacciTests     // Check for inputs with limit values
    {
        private readonly ITestOutputHelper output;

        public FibonacciTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(0,0)]
        //[InlineData(0,Int32.MaxValue)]
        //[InlineData(Int32.MaxValue,0)]
        //[InlineData(Int32.MaxValue, Int32.MaxValue)]
        public void UserInsertsZeroOrMaxValues(int length, int start)
        {
            // Arrange

            // Act
            int actual = Program.Fibonacci(length,start);

            // Assert
            Assert.InRange(actual, 1, 10);
        }

        [Fact]
        public void UserInputNotInt()       // Check default values
        {
            // Arrange
            int lenght = 10;
            int start = 0;

            // Act
            int actual = Program.Fibonacci(lenght, start);

            // Assert
            Assert.InRange(actual, 1, 10);

        }

        [Fact]
        public void DefaultDataProducesActualFibonacciNumbers()     // Check that the function produces actual fibonacci values
        {
            // Arrange
            int lenght = 10;
            int start = 0;
            List<string> prevalues = new List<string>();
            List<string> runvalues = new List<string>();
            string line;
            bool actual = false;

            int tmp = Program.Fibonacci(lenght, start);

            using (StreamReader sr1 = new StreamReader(@"C:\TEMP\VALUES.TXT"))
            {
                while ((line = sr1.ReadLine()) != null)
                {
                    prevalues.Add(line);
                }
            }
            using (StreamReader sr2 = new StreamReader(@"C:\TEMP\FIBONACCI.TXT"))
            {
                while ((line = sr2.ReadLine()) != null)
                {
                    runvalues.Add(line);
                }
            }

            // Act
            foreach (string text in runvalues)
            {
                actual = prevalues.Contains(text);
                //output.WriteLine(text + " " + actual);
                if (actual == false)
                {
                    break;
                };
            }

            // Assert
            Assert.True(actual);
        }
    }
}
