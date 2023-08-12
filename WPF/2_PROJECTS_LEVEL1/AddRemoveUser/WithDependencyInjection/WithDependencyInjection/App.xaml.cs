using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WithDependencyInjection.Services;

namespace WithDependencyInjection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IContainer container = SetupContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                MainWindow window = container.Resolve<MainWindow>();
                window.ShowDialog();
            }

            base.OnStartup(e);
        }

        private static IContainer SetupContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WindowService>().As<IWindowService>();
            builder.RegisterType<NotificationListViewModel>().As<INotificationListViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<UserListViewModel>().As<IUserListViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<MainWindowViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<MainWindow>().InstancePerLifetimeScope();

            var container = builder.Build();
            return container;
        }
    }
}
