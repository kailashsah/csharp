using ChannelViewers.Models;
using ChannelViewers.Stores;
using ChannelViewers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.Command
{
    public class EditCommand: CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public Models.ChannelViewer Viewer { get; }

        public EditCommand(Models.ChannelViewer viewer, ModalNavigationStore modalNavigationStore)
        {
            Viewer = viewer;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            EditViewersVM editViewersVM = new EditViewersVM(null, _modalNavigationStore);
            editViewersVM.ViewersDetailsFormVM.Username = Viewer.Username;
            editViewersVM.ViewersDetailsFormVM.IsSubscribed = Viewer.IsSubscribed;
            editViewersVM.ViewersDetailsFormVM.IsMember = Viewer.IsMember;
            
            _modalNavigationStore.CurrentVM = editViewersVM;

        }
    }
}
