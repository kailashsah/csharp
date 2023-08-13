using ChannelViewers.Models;
using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.ViewModels
{
    public class ViewersDetailsVM: ViewModelBase
    {
        private readonly SelectedViewerStore _selectedViewerStore;
        private ChannelViewer SelectedViewer => _selectedViewerStore.SelectedViewer;

        public bool HasSelectedViewer => SelectedViewer != null;
        public string Username => SelectedViewer?.Username ?? "Unknown";
        public string IsMemberDisplay => (SelectedViewer?.IsMember ?? false) ? "Yes" : "No" ;
        public string IsSubscribedDisplay => (SelectedViewer?.IsSubscribed ?? false) ? "Yes" : "No" ;
        public ViewersDetailsVM(SelectedViewerStore selectedViewerStore)
        {
           
            _selectedViewerStore = selectedViewerStore;
            _selectedViewerStore.SelectedViewerChanged += _selectedViewerStore_SelectedViewerChanged;
        }
        protected override void Dispose()
        {
            _selectedViewerStore.SelectedViewerChanged -= _selectedViewerStore_SelectedViewerChanged;
            base.Dispose();
        }
        private void _selectedViewerStore_SelectedViewerChanged()
        {
            OnPropertyChanged(nameof(HasSelectedViewer));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsMemberDisplay));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
        }
    }
}
