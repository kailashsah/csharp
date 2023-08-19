using ChannelViewers.Command;
using ChannelViewers.Models;
using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChannelViewers.ViewModels
{
    public class ViewersListingItemsVM : ViewModelBase
    {
        public Models.ChannelViewer ChannelViewer { get; }
        public string Username => ChannelViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ViewersListingItemsVM(Models.ChannelViewer channelViewer, ModalNavigationStore modalNavigationStore)
        {
            ChannelViewer = channelViewer;
            EditCommand = new EditCommand(ChannelViewer, modalNavigationStore);
        }
        public override string ToString()
        {
            return Username.ToString();
        }

    }
}
