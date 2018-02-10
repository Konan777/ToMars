using System;
using NUnit.Framework;
using ToMars.Web.Models;
using Moq;

// https://github.com/Moq/moq4/wiki/Quickstart

namespace ToMars.Web.Tests
{
    [TestFixture]
    class SortModel_Test
    {
        [Test]
        public void SortModel_SortForZeroColumns_SortIsEmpty()
        {
            // Arrange
            var sm = new SortModel();
            // Act
            var so = sm.GetSortOrder();
            // Assert
            Assert.True(so.Length == 0);
        }

        [Test]
        public void SortModel_FirstColumnClick_SortAsc()
        {
            // Arrange
            var sm = new SortModel();
            sm.UpdateModel("FIO");
            // Act
            var so = sm.GetSortOrder();
            // Assert
            Assert.True(so == "FIO asc");
        }

        [Test]
        public void SortModel_ColumnClickedTwice_SortDesc()
        {
            // Arrange
            var sm = new SortModel();
            sm.UpdateModel("FIO");
            sm.UpdateModel("FIO");
            // Act
            var so = sm.GetSortOrder();
            // Assert
            Assert.True(so == "FIO desc");
        }

        [Test]
        public void SortModel_ColumnClickedTriple_NoSort()
        {
            // Arrange
            var sm = new SortModel();
            sm.UpdateModel("FIO");
            sm.UpdateModel("FIO");
            sm.UpdateModel("FIO");
            // Act
            var so = sm.GetSortOrder();
            // Assert
            Assert.True(so.Length == 0);
        }

        [Test]
        public void SortModel_TwoCloumns_SortAsc()
        {
            // Arrange
            var sm = new SortModel();
            sm.UpdateModel("FIO");
            sm.UpdateModel("add_Birthday"); // add_ for column clicked with shift
            // Act
            var so = sm.GetSortOrder();
            // Assert
            Assert.True(so == "FIO asc, Birthday asc");
        }

        [Test]
        public void SortModel_TwoCloumns_SortDesc()
        {
            // Arrange
            var sm = new SortModel();
            sm.UpdateModel("FIO");
            sm.UpdateModel("add_Birthday");
            sm.UpdateModel("add_FIO");
            sm.UpdateModel("add_Birthday");
            // Act
            var so = sm.GetSortOrder();
            // Assert
            Assert.True(so == "FIO desc, Birthday desc");
        }
    }
}
