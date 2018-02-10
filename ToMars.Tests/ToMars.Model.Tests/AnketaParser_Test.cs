using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ToMars.Model;
using ToMars.Model.Context;
using ToMars.Model.Entities;
using ToMars.Model.Parser;

// https://github.com/Moq/moq4/wiki/Quickstart

namespace UnitTest.Tests
{
    [TestFixture]
    class AnketaParser_Test
    {
        [Test]
        public void FileAlreadyParsed_Check_Correct()
        {
            // Arrange
            var ikep = new Mock<ITMRepositary>();
            var afl = new AnketaFile() { FileName = "", ID = 1};
            ikep.Setup(s => s.GetFile(It.IsAny<string>())).Returns(afl);
            Mock<IGeneralFacade> igf = new Mock<IGeneralFacade>();
            igf.Setup(s => s.Keeper).Returns(ikep.Object);
            // Act
            var pars = new AnketaParser(igf.Object);
            // Assert
            Assert.True(pars.FileAlreadyParsed(""));
        }

        [Test]
        public async Task Parse_SigleAsync_ThreeRows_Found()
        {
            // Arrange (create)
            var ikep = new Mock<ITMRepositary>();
            var irea = new Mock<IReader>();
            var ilog = new Mock<ILogger>();
            var icon = new Mock<IConverter>();
            var ank = new Anketa()
            {
                FIO = "Петухова Людмила Игнатьевна",
                Birthday = DateTime.Now,
                Email = "vcywd@eaacc.rnh",
                Phone = "8966358271"
            };
            // Arrange (setup)
            icon.Setup(s => s.ConvertIt<Anketa>(It.IsAny<string>())).Returns(ank);
            var calls = 0;
            AnketaFile ankfile=null;
            // Set up IReader for read data three times
            irea.Setup(s => s.EndOfStream()).Returns(() => calls==3).Callback(() => calls++);
            // InsertFileAsync must return AnketaFile for assertion
            ikep.Setup(s => s.InsertFileAsync(It.IsAny<AnketaFile>())).
                Returns(Task.Run(() => {})).
                Callback<AnketaFile>(af => ankfile = af);
            Mock<IGeneralFacade> igf = new Mock<IGeneralFacade>();
            igf.Setup(s => s.Keeper).Returns(ikep.Object);
            igf.Setup(s => s.Reader).Returns(irea.Object);
            igf.Setup(s => s.Logger).Returns(ilog.Object);
            igf.Setup(s => s.Converter).Returns(icon.Object);

            var pars = new AnketaParser(igf.Object);
            // Act
            await pars.Parse_SigleAsync("", new Progress<int>(), new CancellationTokenSource());
            // Assert
            Assert.True(ankfile.Rows.Count==3);
        }
    }
}
