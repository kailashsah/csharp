using ChannelViewers.Models;
using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.ViewModels
{
    public class ViewersListingVM: ViewModelBase
    {
        private readonly SelectedViewerStore _selectedViewerStore;
        private readonly ObservableCollection<ViewersListingItemsVM> _viewersListingItemsVMs;
        public IEnumerable<ViewersListingItemsVM> ViewersListingItemsVMs => _viewersListingItemsVMs;
        private ViewersListingItemsVM _selectedViewersListingItemsVM;

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

        public ViewersListingVM(SelectedViewerStore selectedViewerStore)
        {
            _selectedViewerStore = selectedViewerStore;
            _viewersListingItemsVMs = new ObservableCollection<ViewersListingItemsVM>();
            _viewersListingItemsVMs.Add(new ViewersListingItemsVM (new ChannelViewer("Mary", true, false ) ));
            _viewersListingItemsVMs.Add(new ViewersListingItemsVM(new ChannelViewer("Merry", true, false) ));
            _viewersListingItemsVMs.Add(new ViewersListingItemsVM(new ChannelViewer("Moraco", true, false) ));
        }
    }
}
