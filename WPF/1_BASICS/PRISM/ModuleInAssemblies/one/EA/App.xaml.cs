using Prism.Ioc; //Resolve<MainWindow>, IContainerRegistry
using Prism.Modularity; // IModuleCatalog
using Prism.Unity; // PrismApplication
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EA
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
            //throw new NotImplementedException();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //throw new NotImplementedException();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleA.ModAModule>();
            moduleCatalog.AddModule<ModuleB.ModBModule>();
            //base.ConfigureModuleCatalog(moduleCatalog);
        }
    }
}
