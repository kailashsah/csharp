using ChannelViewers.Stores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.Command
{
    public class CloseModalCommand : CommandBase
    {
        public CloseModalCommand(ModalNavigationStore modalNavigationStore)
        {
            ModalNavigationStore = modalNavigationStore;
        }

        public ModalNavigationStore ModalNavigationStore { get; }

        public override void Execute(object parameter)
        {
            ModalNavigationStore.Close();
        }

        ~CloseModalCommand()
        {
            Trace.WriteLine("dtor", this.GetType().Name);
        }
    }
}
