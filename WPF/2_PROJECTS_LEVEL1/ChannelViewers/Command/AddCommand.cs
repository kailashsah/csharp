using ChannelViewers.Command;
using ChannelViewers.Stores;
using ChannelViewers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.NewFolder.Command
{
    public class AddCommand : CommandBase
    {
        private readonly AddViewerStore addViewerStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddCommand(AddViewerStore addViewerStore, ModalNavigationStore modalNavigationStore)
        {
            this.addViewerStore = addViewerStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            _modalNavigationStore.CurrentVM = new AddViewersVM(this.addViewerStore, _modalNavigationStore);


        }
    }
}
