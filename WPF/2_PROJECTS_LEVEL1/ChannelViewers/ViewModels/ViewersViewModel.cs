using ChannelViewers.NewFolder.Command;
using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChannelViewers.ViewModels
{
    public class ViewersViewModel : ViewModelBase
    {
        public ViewersListingVM ViewersListingVM { get; set; }
        public ViewersDetailsVM ViewersDetailsVM { get; set; }
        public ICommand AddViewersCommand { get; }
        public ViewersViewModel(AddViewerStore addViewerStore, SelectedViewerStore selectedViewerStore, ModalNavigationStore modalNavigationStore)
        {
            ViewersListingVM = new ViewersListingVM(addViewerStore, selectedViewerStore, modalNavigationStore);
            ViewersDetailsVM = new ViewersDetailsVM(selectedViewerStore);

            AddViewersCommand = new AddCommand(addViewerStore, modalNavigationStore);
        }
    }
}
