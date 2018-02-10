using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using PagedList;
using ToMars.Model;
using ToMars.Model.Models;
using ToMars.Model.Entities;
using ToMars.Model.Settings;
using ToMars.WPF.ViewModel;

namespace UnitTest.Tests
{
    [TestFixture]
    class MainViewModel_Test
    {
        private Mock<IGeneralFacade> FacadeWithSettingsCheck()
        {
            var iset = new Mock<ISettings>();
            var iseldb = new Mock<ToMars.Model.Context.Database>();
            iseldb.Setup(s => s.ConnectionIsValid()).Returns(true);
            iset.Setup(s => s.SelectedDatabase).Returns(iseldb.Object);
            Mock<IGeneralFacade> igf = new Mock<IGeneralFacade>();
            igf.Setup(s => s.Settings).Returns(iset.Object);

            return igf;
        }

        [Test]
        public void SelectedRow_Null_NotAllowDelChg()
        {
            // Arrange
            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.SelectedRow = null;
            // Assert
            Assert.True(mod.AllowDelChg==false);
        }
        [Test]
        public void SelectedRow_NotNull_AllowDelChg()
        {
            // Arrange
            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            var ikep = new Mock<ITMRepositary>();
            ikep.Setup(s => s.GetFilesAsync()).Returns(
                Task<List<AnketaFile>>.Run(() => {
                    return new List<AnketaFile>();
                })
            );
            igf.Setup(s => s.Keeper).Returns(ikep.Object);
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.SelectedRow = new AnketaViewModel();
            // Assert
            Assert.True(mod.AllowDelChg == true);
        }
        [Test]
        public void SelectedFile_Null_NotAllowAdd()
        {
            // Arrange
            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.SelectedFile = null;
            // Assert
            Assert.True(mod.AllowAdd == false);
        }
        [Test]
        public void SelectedFile_NotNull_AllowAdd()
        {
            // Arrange
            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.SelectedFile = new AnketaFile();
            // Assert
            Assert.True(mod.AllowAdd == true);
        }

        [Test]
        public void ProcessSingle_OneFromThree_ProgressCorrect()
        {
            // Arrange
            var ikep = new Mock<ITMRepositary>();
            ikep.Setup(s => s.GetFilesAsync()).Returns(
                Task<List<AnketaFile>>.Run(() => {
                    return new List<AnketaFile>();
                })
            );

            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            igf.Setup(s => s.Parser).Returns(new FakeParser());
            igf.Setup(s => s.Keeper).Returns(ikep.Object);
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.CmdProcess.Execute(null);
            Thread.Sleep(200);
            // Assert

            Assert.True(
                (mod.ProgressBarMaximum==3) &&
                (mod.ProgressBarValue == 1) &&
                (mod.AllowStop) &&
                (mod.StatuBarVisiblity)
            );
        }
        [Test]
        public void ProcessSingle_Cancelation_Ok()
        {
            // Arrange
            var ikep = new Mock<ITMRepositary>();
            ikep.Setup(s => s.GetFilesAsync()).Returns(
                Task<List<AnketaFile>>.Run(() => {
                    return new List<AnketaFile>();
                })
            );
            var imess = new Mock<IMessenger>();

            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            var ipars = new FakeParser();
            igf.Setup(s => s.Parser).Returns(ipars);
            igf.Setup(s => s.Messenger).Returns(imess.Object);
            igf.Setup(s => s.Keeper).Returns(ikep.Object);
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.CmdProcess.Execute(null);
            Thread.Sleep(100);
            mod.CmdStop.Execute(null);
            Thread.Sleep(200);
            // Assert
            Assert.True(
                (!mod.AllowStop) &&
                (!mod.StatuBarVisiblity)
            );
        }
        [Test]
        public void ProcessSingle_ToTheEnd_AllOk()
        {
            // Arrange
            IProgress<int> progress = new Progress<int>();
            var ipars = new Mock<IParser>();
            ipars.Setup(s => s.Parse_SigleAsync(It.IsAny<string>(), progress, null));

            var ikep = new Mock<ITMRepositary>();
            ikep.Setup(s => s.GetFilesAsync()).Returns(
                Task<List<AnketaFile>>.Run(() => {
                    return new List<AnketaFile>();
                })
            );

            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            igf.Setup(s => s.Parser).Returns(ipars.Object);
            igf.Setup(s => s.Keeper).Returns(ikep.Object);
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.CmdProcess.Execute(null);
            // Assert
            Assert.True(
                (!mod.AllowStop) &&
                (!mod.StatuBarVisiblity)
            );
        }
        [Test]
        public void ProcessSingle_Exception_Catched()
        {
            // Arrange
            var ikep = new Mock<ITMRepositary>();
            ikep.Setup(s => s.GetFilesAsync()).Returns(
                Task<List<AnketaFile>>.Run(() => {
                    return new List<AnketaFile>();
                })
            );
            string message = ""; // Incoming paramater of IMessenger.ShowMessage
            var imess = new Mock<IMessenger>();
            imess.Setup(s => s.ShowMessage(It.IsAny<string>())).Callback<string>(r => message = r);

            Mock<IGeneralFacade> igf = FacadeWithSettingsCheck();
            var ipars = new FakeParser();
            igf.Setup(s => s.Parser).Returns(ipars);
            igf.Setup(s => s.Messenger).Returns(imess.Object);
            igf.Setup(s => s.Keeper).Returns(ikep.Object);
            var mod = new MainViewModel(igf.Object);
            // Act
            mod.CmdProcessMultithread.Execute(null);
            Thread.Sleep(100);
            mod.CmdStop.Execute(null);
            Thread.Sleep(200);
            // Assert
            StringAssert.Contains(message, "Test exception");
        }
    }

    // Can't fake "await Task.Run" within Return. Maked FakeParser..
    public class FakeParser : IParser
    {
        public bool FileAlreadyParsed(string FileName)
        {
            return false;
        }

        public  Task<int> RowsInAnketa(string FileName)
        {
            return Task.Run<int>(() => { return 3; });
        }

        public async Task Parse_SigleAsync(string FileName, IProgress<int> Progress, CancellationTokenSource _cancel)
        {
            await Task.Run(() => {
                while (true) {
                    if (_cancel.IsCancellationRequested)
                        _cancel.Token.ThrowIfCancellationRequested();
                    Progress.Report(1);
                    Thread.Sleep(100);
                }
            });
        }

        public async Task Parse_MultipleAsync(string FileName, IProgress<int> Progress, CancellationTokenSource _cancel)
        {
            await Task.Run(() => {
                while (true)
                {
                    if (_cancel.IsCancellationRequested)
                        throw new Exception("Test exception");
                    Progress.Report(1);
                    Thread.Sleep(100);
                }
            });
        }
    }
}
