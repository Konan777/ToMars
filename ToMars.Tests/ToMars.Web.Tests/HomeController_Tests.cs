using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using ToMars.Web.Controllers;
using ToMars.Model;
using Moq;
using PagedList;
using ToMars.Model.Entities;
using ToMars.Model.Settings;
using ToMars.Model.Context;

// https://github.com/Moq/moq4/wiki/Quickstart

namespace ToMars.Web.Tests
{
    [TestFixture]
    class HomeController_Tests
    {
        private Mock<IGeneralFacade> SetupEmptyFacade()
        {
            var ikep = new Mock<ITMRepositary>();
            ikep.Setup(s => s.GetFiles()).Returns(new List<AnketaFile>());
            ikep.Setup(s => s.GetAnketasByPage(
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())
            ).Returns((new List<Anketa>()).ToPagedList(1,1));
            var iset = new Mock<ISettings>();
            var iseldb = new Mock<Database>();
            iseldb.Setup(s => s.ConnectionIsValid()).Returns(true);
            iset.Setup(s => s.SelectedDatabase).Returns(iseldb.Object);
            Mock<IGeneralFacade> igf = new Mock<IGeneralFacade>();
            igf.Setup(s => s.Settings).Returns(iset.Object);
            igf.Setup(s => s.Keeper).Returns(ikep.Object);

            return igf;
        }

        private Mock<IGeneralFacade> SetupFilledFacade()
        {
            var ikep = new Mock<ITMRepositary>();
            ikep.Setup(s => s.GetFiles()).Returns(
                new List<AnketaFile>() {
                    new AnketaFile(), new AnketaFile()
                }
            );
            List<Anketa> ankl = new List<Anketa>();
            for (int i = 0; i < 50; i++)
                ankl.Add(new Anketa());
            ikep.Setup(s => s.GetAnketasByPage(
                    It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())
                ).Returns((int fileId, int page, int pageSize, string sort) =>
                {
                    return (ankl).ToPagedList(page, pageSize);
                });
            //).Returns((ankl).ToPagedList(p => p.page, 10));
            var iset = new Mock<ISettings>();
            var iseldb = new Mock<Database>();
            iseldb.Setup(s => s.ConnectionIsValid()).Returns(true);
            iset.Setup(s => s.SelectedDatabase).Returns(iseldb.Object);
            Mock<IGeneralFacade> igf = new Mock<IGeneralFacade>();
            igf.Setup(s => s.Settings).Returns(iset.Object);
            igf.Setup(s => s.Keeper).Returns(ikep.Object);

            return igf;
        }

        private void SetUpController(HomeController controller)
        {
            // moq session state
            var mockControllerContext = new Mock<ControllerContext>();
            var mockSession = new Mock<HttpSessionStateBase>();
            mockSession.SetupGet(s => s["ReturnProductAddressID"]).Returns("123"); //somevalue
            mockControllerContext.Setup(p => p.HttpContext.Session).Returns(mockSession.Object);
            controller.ControllerContext = mockControllerContext.Object;
        }

        [Test]
        public void Index_HaveNoFiles()
        {
            // Arrange
            var ifacade = SetupEmptyFacade();
            var controller = new HomeController(ifacade.Object);
            SetUpController(controller);
            // Act
            ViewResult result = controller.Index(1) as ViewResult;
            // Assert
            Assert.IsTrue(result.ViewBag.Files.Items.Count == 0);
        }

        [Test]
        public void Index_ConnectioStringIsEmpty()
        {
            // Arrange
            var ifacade = SetupEmptyFacade();
            var controller = new HomeController(ifacade.Object);
            SetUpController(controller);
            // Act
            ViewResult result = controller.Index(1) as ViewResult;
            // Assert
            Assert.IsNotNull(result.ViewBag.ConnectionString == "");
        }

        [Test]
        public void Index_AnketaList_HaveTwoRows()
        {
            // Arrange
            var ifacade = SetupFilledFacade();
            var controller = new HomeController(ifacade.Object);
            SetUpController(controller);
            // Act
            ViewResult result = controller.Index(1) as ViewResult;
            // Assert
            Assert.IsTrue(result.ViewBag.Files.Items.Count == 2);
        }

        [Test]
        public void Index_Anketas_HaveFiftyRows()
        {
            // Arrange
            var ifacade = SetupFilledFacade();
            var controller = new HomeController(ifacade.Object);
            SetUpController(controller);
            // Act
            ViewResult result = controller.Index(1) as ViewResult;
            // Assert
            Assert.IsTrue((result.Model as IPagedList).TotalItemCount==50);
        }

        [Test]
        public void Index_SortedByFIOAsc()
        {
            // Arrange
            var ifacade = SetupFilledFacade();
            var controller = new HomeController(ifacade.Object);
            SetUpController(controller);
            // Act
            ViewResult result = controller.Index(1, 1, "FIO") as ViewResult;
            // Assert
            Assert.IsTrue(result.ViewBag.SortModel.GetSort("FIO") == "asc");
        }

        [Test]
        public void Index_PageThreeSelected()
        {
            // Arrange
            var ifacade = SetupFilledFacade();
            var controller = new HomeController(ifacade.Object);
            SetUpController(controller);
            // Act
            ViewResult result = controller.Index(1, 3) as ViewResult;
            // Assert
            Assert.IsTrue((result.Model as IPagedList).PageNumber == 3);
        }

        [Test]
        public void ApplySettings_Correct()
        {
            // Arrange
            var ifacade = SetupEmptyFacade();
            var controller = new HomeController(ifacade.Object);
            SetUpController(controller);
            // Act
            ContentResult result = controller.ApplySettings("new settings") as ContentResult;
            // Assert
            Assert.IsTrue(result.Content.Contains("успешно"));
        }

    }
}
