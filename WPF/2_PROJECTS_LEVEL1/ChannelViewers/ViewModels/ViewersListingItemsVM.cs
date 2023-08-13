using ChannelViewers.Models;
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
        public ChannelViewer ChannelViewer { get; }
        public string Username => ChannelViewer.Username;
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ViewersListingItemsVM(ChannelViewer channelViewer)
        {
            ChannelViewer = channelViewer;
        }
        public override string ToString()
        {
            return Username.ToString();
        }

    }
}
