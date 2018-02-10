using System;
using log4net;
using log4net.Config;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace ToMars.Model
{
    public interface ILogger
    {
        void Log(string message, Exception exc = null);
    }
    public class Logger : ILogger
    {
        private ILog log;

        public Logger()
        {
            SetUp();
        }

        private void SetUp()
        {
            BasicConfigurator.Configure();
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            var layout = new PatternLayout();
            layout.ConversionPattern = "%date [%2thread] %-5level %logger{1} - %message%newline";
            layout.ActivateOptions();

            var appender = new log4net.Appender.RollingFileAppender()
            {
                Layout = layout,
                File = @"logs\ToMars.log",
                Encoding = System.Text.Encoding.UTF8,
                AppendToFile = true,
                Name = "File",
                StaticLogFileName = true
            };
            appender.ActivateOptions();
            hierarchy.Root.AddAppender(appender);

            log = LogManager.GetLogger("File");
        }

        public void Log(string message, Exception exc)
        {
            if (exc!=null)
                log.Error(message, exc);
            else
                log.Info(message);
        }
    }
}
