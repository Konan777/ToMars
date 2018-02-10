using System;
using System.Collections.Generic;
using NUnit.Framework;
using ToMars.Model.Entities;
using ToMars.Model.Parser;
using Moq;
using ToMars.Model;

namespace UnitTest
{
    [TestFixture]
    public class StringToAnketaTest
    {
        private Dictionary<string, int> ColumnSizes;
        
        public StringToAnketaTest()
        {

            ColumnSizes = new Dictionary<string, int>();
            ColumnSizes.Add("FIO", 150);
            ColumnSizes.Add("Email", 20);
            ColumnSizes.Add("Phone", 50);
        }

        [TestCase("Цветкова Наталья Николаевна", "Not all fields filled!")]
        [TestCase("Цветкова Наталья Николаевна;;;", "String was not recognized as a valid DateTime.")]
        public void ConvertIt_WrongData_ExceptionThrown(string Line, string result)
        {
            // Arrange
            var Converter = new ToAnketa(';');
            // Act
            var ex = Assert.Catch<Exception>(() => Converter.ConvertIt<Anketa>(Line));
            // Assert
            StringAssert.Contains(result, ex.Message);
        }

        [TestCase("Цветкова Наталья Николаевна;12.05.2016;zbkzr@dvenq.cds;+79638099999")]
        public void ConvertIt_CorrectData_NoExceptionThrown(string Line)
        {
            // Arrange
            var Converter = new ToAnketa(';');
            // Act
            // Assert
            Assert.That(() => Converter.ConvertIt<Anketa>(Line), Throws.Nothing);
        }

    }

}
