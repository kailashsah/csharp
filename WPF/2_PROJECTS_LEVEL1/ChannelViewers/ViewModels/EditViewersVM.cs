using ChannelViewers.Command;
using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChannelViewers.ViewModels
{
    public class EditViewersVM: ViewModelBase
    {
        public ViewersDetailsFormVM ViewersDetailsFormVM { get; set; }
        ~EditViewersVM()
        {
            Trace.WriteLine("dtor", this.GetType().Name);
        }

        public EditViewersVM(AddViewerStore addViewerStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new SubmitCommand(addViewerStore, modalNavigationStore);
            ICommand closeCommand = new CloseModalCommand(modalNavigationStore);
            ViewersDetailsFormVM = new ViewersDetailsFormVM(submitCommand, closeCommand);
        }
    }
}
