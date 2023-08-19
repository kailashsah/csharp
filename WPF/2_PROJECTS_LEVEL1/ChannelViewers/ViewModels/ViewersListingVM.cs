using ChannelViewers.Command;
using ChannelViewers.Models;
using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChannelViewers.ViewModels
{
    public class ViewersListingVM : ViewModelBase
    {
        private readonly AddViewerStore _addViewerStore;
        private readonly SelectedViewerStore _selectedViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ObservableCollection<ViewersListingItemsVM> _viewersListingItemsVMs;
        private ViewersListingItemsVM _selectedViewersListingItemsVM;
        public IEnumerable<ViewersListingItemsVM> ViewersListingItemsVMs => _viewersListingItemsVMs;
        
        
        public ViewersListingItemsVM SelectedViewersListingItemsVM
        {
            get { return _selectedViewersListingItemsVM; }
            set
            {
                _selectedViewersListingItemsVM = value;
                OnPropertyChanged(nameof(SelectedViewersListingItemsVM));
                _selectedViewerStore.SelectedViewer = _selectedViewersListingItemsVM?.ChannelViewer;
            }
        }

        public ViewersListingVM(AddViewerStore addViewerStore, SelectedViewerStore selectedViewerStore, ModalNavigationStore modalNavigationStore)
        {
            _addViewerStore = addViewerStore;
            _selectedViewerStore = selectedViewerStore;
            _modalNavigationStore = modalNavigationStore;
            _addViewerStore.ViewerAdded += AddViewerStore_ViewerAdded;

            _viewersListingItemsVMs = new ObservableCollection<ViewersListingItemsVM>();
            //_viewersListingItemsVMs.Add(new ViewersListingItemsVM(new ChannelViewer("Mary", true, false), modalNavigationStore));
            AddViwersVMToCollection(new Models.ChannelViewer("Mary", true, false), modalNavigationStore);
            _viewersListingItemsVMs.Add(new ViewersListingItemsVM(new Models.ChannelViewer("Merry", true, false), modalNavigationStore));
            _viewersListingItemsVMs.Add(new ViewersListingItemsVM(new Models.ChannelViewer("Moraco", true, false), modalNavigationStore));
           
        }
        public void AddViwersVMToCollection(Models.ChannelViewer channelViewer, ModalNavigationStore modalNavigationStore)
        {
            _viewersListingItemsVMs.Add(new ViewersListingItemsVM(channelViewer, modalNavigationStore));
        }
        private void AddViewerStore_ViewerAdded(Models.ChannelViewer channelViewer)
        {
            AddViwersVMToCollection(channelViewer, _modalNavigationStore);

        }

        protected override void Dispose()
        {
            _addViewerStore.ViewerAdded -= AddViewerStore_ViewerAdded;
            base.Dispose();
        }
    }
}
