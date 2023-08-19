using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.ViewModels
{
    public class MainWindowVM: ViewModelBase
    {
        public MainWindowVM(ModalNavigationStore modalNavigationStore, ViewersViewModel viewersViewModel)
        {
            ModalNavigationStore = modalNavigationStore;
            ViewersViewModel = viewersViewModel;
            ModalNavigationStore.SelectionChanged += ModalNavigationStore_SelectionChanged;
            //ModalNavigationStore.CurrentVM = new EditViewersVM();
        }

       
        public bool IsModalOpen => ModalNavigationStore.IsOpen;
        public ModalNavigationStore ModalNavigationStore { get; }
        public ViewersViewModel ViewersViewModel { get; }
        public ViewModelBase CurrentViewModel => ModalNavigationStore.CurrentVM;

        private void ModalNavigationStore_SelectionChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
        protected override void Dispose()
        {
            ModalNavigationStore.SelectionChanged -= ModalNavigationStore_SelectionChanged;
            base.Dispose();
        }
    }
}
