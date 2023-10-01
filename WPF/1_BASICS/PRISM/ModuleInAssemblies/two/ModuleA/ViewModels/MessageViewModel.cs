using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using UsingEventAggregator.Core;

namespace ModuleA.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        IEventAggregator _ea;

        private string _message = "Message to Send";
        public string Message
        {
            get { return _message; }
            set { 
                SetProperty(ref _message, value);
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage, CanExecuteMethod);
            // .ObservesProperty<string>(()=>Message) // is not working
        }

        private bool CanExecuteMethod()
        {
            return !string.IsNullOrEmpty(Message);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
