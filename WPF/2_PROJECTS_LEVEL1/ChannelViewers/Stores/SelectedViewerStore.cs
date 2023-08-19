using ChannelViewers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.Stores
{
    public class SelectedViewerStore
    {
        private Models.ChannelViewer _channelViewer;

        public Models.ChannelViewer SelectedViewer
        {
            get { return _channelViewer; }
            set { 
                _channelViewer = value;
                SelectedViewerChanged?.Invoke();
            }
        }
        public event Action SelectedViewerChanged;
    }
}
