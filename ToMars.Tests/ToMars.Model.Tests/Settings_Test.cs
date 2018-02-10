using NUnit.Framework;
using ToMars.Model.Settings;
using Moq;

// https://github.com/Moq/moq4/wiki/Quickstart

namespace UnitTest
{
    [TestFixture]
    class Settings_Test
    {
        [Test]
        public void Settings_RestoreDefaults_NoItemsFound()
        {
            // Arrange
            Mock<ISettingsSerializer> iss = new Mock<ISettingsSerializer>();
            iss.Setup(ld => ld.Serialize(It.IsAny<BaseSettings>())).Returns("");
            iss.Setup(ld => ld.Deserialize(It.IsAny<string>())).Returns(new BaseSettings());
            Mock<ISettingKeeper> isk = new Mock<ISettingKeeper>();
            isk.Setup(ld => ld.Save(It.IsAny<string>()));
            isk.Setup(ld => ld.Load()).Returns("");
            Mock<ToMars.Model.ILogger> ilg = new Mock<ToMars.Model.ILogger>();
            ilg.Setup(ld => ld.Log(It.IsAny<string>(), null));
            var sett = new Setting(iss.Object, isk.Object, ilg.Object);
            // Act
            sett.Restore();
            // Assert
            Assert.True(sett.Databases.Count==0);
        }
    }
}
