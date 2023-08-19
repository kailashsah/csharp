using ChannelViewers.Models;
using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.Command
{
    public class SubmitCommand : AsyncCommandBase
    {
        private readonly AddViewerStore addViewerStore;

        public SubmitCommand(AddViewerStore addViewerStore, ModalNavigationStore modalNavigationStore)
        {
            this.addViewerStore = addViewerStore;
            ModalNavigationStore = modalNavigationStore;
        }

        public ModalNavigationStore ModalNavigationStore { get; }


        public override async Task ExecuteAsync(object parameter)
        {
            //Models.ChannelViewer viewer = new Models.ChannelViewer();
            ModalNavigationStore.Close();
        }
    }
}