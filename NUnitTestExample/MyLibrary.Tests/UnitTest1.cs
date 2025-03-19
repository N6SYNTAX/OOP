using NUnit.Framework;
using System;
using MyLibrary;
namespace MyLibrary.Tests;

public class Tests
{
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Subtract_ShouldReturnCorrectResult()
        {
            int result = calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }
    }
}