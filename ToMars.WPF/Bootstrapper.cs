using Autofac;
using ToMars.Model;
using ToMars.Model.Context;
using ToMars.Model.Parser;
using ToMars.Model.Settings;
using ToMars.WPF.ViewModel;
using ToMars.Views;
using log4net;


namespace ToMars
{
    public static class Bootstrapper
    {
        // http://docs.autofac.org/en/latest/register/prop-method-injection.html#property-injection
        // http://docs.autofac.org/en/latest/register/registration.html
        // http://docs.autofac.org/en/latest/best-practices/
        // http://docs.autofac.org/en/latest/register/index.html

        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
            builder.RegisterType<BaseSettings>().As<BaseSettings>();
            builder.RegisterType<SettingsToFile>().As<ISettingKeeper>().SingleInstance();
            builder.RegisterType<MarsXmlSerializer>().As<ISettingsSerializer>().SingleInstance();
            // ^^^ Setting Dependencies
            builder.RegisterType<Setting>().As<ISettings>().SingleInstance();

            //builder.RegisterType<Anketa>().As<Anketa>();
            //builder.RegisterType<AnketaFile>().As<AnketaFile>();
            //builder.RegisterType<AnketaKeeper>().As<IAnketaKeeper>().SingleInstance();
            //builder.RegisterType<ToAnketa>().As<IConverter>();
            // MainViewModel(IAnketaModel _anketaModel, Setting _setting, IParser _parser)

            builder.RegisterType<GeneralFacade>().As<IGeneralFacade>().SingleInstance();
            builder.RegisterType<MainViewModel>().As<MainViewModel>().SingleInstance();
            builder.RegisterType<MainView>().As<MainView>().SingleInstance();

            var container = builder.Build();
            return container;
        }
    }
}