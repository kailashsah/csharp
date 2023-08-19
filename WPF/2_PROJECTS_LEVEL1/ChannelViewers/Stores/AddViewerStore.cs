using ChannelViewers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.Stores
{
    public class AddViewerStore
    {
        public event Action<Models.ChannelViewer> ViewerAdded;

        public async Task Add(Models.ChannelViewer channelViewer)
        {
            ViewerAdded?.Invoke(channelViewer);
        }
    }
}
