using Autofac;
using System.Windows;
using ToMars.Model;
using ToMars.Views;
using ToMars.Model;
using ToMars.Model.Settings;
using ToMars.Model.Context;
using ToMars.Model.Entities;
using ToMars.Model.Models;
using ToMars.WPF.ViewModel;
using AutoMapper;
using System;

namespace ToMars
{
    public partial class App
    {
        public static IContainer Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppDomain.CurrentDomain.UnhandledException +=
                (sender, args) => CurrentDomainOnUnhandledException(args);

            Container = Bootstrapper.Bootstrap();
            var settings = Container.Resolve<ISettings>();
            settings.Restore();
            SetUpDatabase(settings);
            MapperBootstrap();

            // var rep2 = App.Container.Resolve<IParser>();

            var mv = Container.Resolve<MainView>();
            mv.Show();
            mv.Closing += (sender, args) =>
            {
                Application.Current.Shutdown();
            };
        }

        private static void CurrentDomainOnUnhandledException(UnhandledExceptionEventArgs args)
        {
            var exception = args.ExceptionObject as Exception;
            var terminatingMessage = args.IsTerminating ? " The application is terminating." : string.Empty;
            var exceptionMessage = exception?.Message ?? "An unmanaged exception occured.";
            var message = string.Concat(exceptionMessage, terminatingMessage);
            MessageBox.Show(exception.Message);
        }

        private void MapperBootstrap()
        {
            // Настройка AutoMapper
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Anketa, AnketaModel>();
                cfg.CreateMap<AnketaModel, Anketa>();
                cfg.CreateMap<Anketa, AnketaViewModel>();
            });
        }

        private void SetUpDatabase(ISettings sett)
        {
            //throw new Exception("Test exception");
            sett.Restore();
            if (sett.Databases.Count == 0)
            {
                var sqlite = new SQLite_Database() {
                    Name = "SQLite", ConnectionString = @"Data Source=C:\Work\ToMars\DB\ToMars.db",
                };
                var mssql = new MSSQL_Database()
                {
                    Name = "MSSQL",
                    ConnectionString =
                        //@"Data Source=AMUR-GO-220\SQLEXPRESS;initial catalog=Bookz;integrated security=True;Connect Timeout=5;"
                        "Data Source=KONAN-PC;initial catalog=Books;integrated security=True;Connect Timeout=30"
                };
                sett.Databases.Add(sqlite);
                sett.Databases.Add(mssql);
                sett.SelectedDatabase = sqlite;
            }
            
        }

    }
}
