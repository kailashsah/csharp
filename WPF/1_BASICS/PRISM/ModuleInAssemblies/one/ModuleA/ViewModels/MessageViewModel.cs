using EA.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModuleA.ViewModels
{
    class MessageViewModel : BindableBase
    {
        private string _msg = "message to send";

        public string Message
        {
            get { return _msg; }
            //set { _msg = value; }
            set { SetProperty(ref _msg, value); }
        }
        public DelegateCommand SendMessageCommand { get; private set; }
        IEventAggregator _ea;
        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
