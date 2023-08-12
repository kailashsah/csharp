using EA.Core;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ModuleB
{
    class ListMsgViewModel : BindableBase
    {
        IEventAggregator _ea;

        private ObservableCollection<string> _messages;

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            //set { messages = value; }
            set { SetProperty(ref _messages, value); }
        }
        public ListMsgViewModel(IEventAggregator ea)
        {
            _ea = ea;
            _messages = new ObservableCollection<string>();
            _ea.GetEvent<MessageSentEvent>().Subscribe(ReceivedMessages);
        }

        private void ReceivedMessages(string obj)
        {
            Messages.Add(obj);
        }
    }
}
