using ChannelViewers.Stores;
using ChannelViewers.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChannelViewers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly SelectedViewerStore _selectedViewerStore;
        public App()
        {
            _selectedViewerStore = new SelectedViewerStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new ViewersViewModel(_selectedViewerStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
