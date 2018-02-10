using System;
using System.Collections.Generic;
using NUnit.Framework;
using ToMars.Model.Entities;
using ToMars.Model.Parser;
using Moq;
using ToMars.WPF.ViewModel;

namespace UnitTest.Database
{
    [TestFixture]
    class Converter_Test
    {
        public Converter_Test()
        {
        }

        //[TestCase(";12.05.2016;zbkzr@dvenq.cds;522212", "FIO Поле должно быть установлено")]
        //[TestCase("Цветкова Наталья Николаевна;01.05.2016;;", "Email Поле должно быть установлено")]
        //[TestCase("Цветкова Наталья Николаевна;01.05.2016;zbkzr@dvenqcdsqweqweqweqweqwe.com;", "Phone Поле должно быть установлено")]
        [TestCase("Цветкова Наталья Николаевна;01.05.2016;zbkzr@dvenqcds;", "Email Неверный EMail")]
        //[TestCase("Цветкова Наталья Николаевна;15.15.2050;zbkzr@dvenqcds.com;+79638098888", "String was not recognized as a valid DateTime.")]
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
