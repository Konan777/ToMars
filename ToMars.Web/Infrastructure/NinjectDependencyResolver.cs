using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Web.Mvc;
using ToMars.Model;
using ToMars.Model.Settings;

namespace ToMars.WEB.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver {
        
        // https://github.com/ninject/Ninject/wiki/Contextual-Binding

        private IKernel kernel;

        public NinjectDependencyResolver() {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            //kernel.Bind<IGeneralFacade>().To<GeneralFacade>();
            kernel.Bind<IGeneralFacade>().To<GeneralFacade>().InSingletonScope();

            kernel.Bind<ILogger>().To<Logger>().InSingletonScope();
            kernel.Bind<BaseSettings>().To<BaseSettings>().InSingletonScope();
            kernel.Bind<ISettingKeeper>().To<SettingsToFile>().InSingletonScope();
            kernel.Bind<ISettingsSerializer>().To<MarsXmlSerializer>().InSingletonScope();
            kernel.Bind<ISettings>().To<Setting>().InSingletonScope();
        }
    }
}