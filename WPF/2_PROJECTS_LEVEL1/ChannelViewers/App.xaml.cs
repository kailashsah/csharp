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
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SelectedViewerStore _selectedViewerStore;
        private readonly AddViewerStore _addViewerStore;
        public App()
        {
            _selectedViewerStore = new SelectedViewerStore();
            _addViewerStore = new AddViewerStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            ModalNavigationStore _modalNavigationStore = new ModalNavigationStore();
            ViewersViewModel viewersViewModel = new ViewersViewModel(
                _addViewerStore,
                _selectedViewerStore, 
                _modalNavigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(_modalNavigationStore, viewersViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
