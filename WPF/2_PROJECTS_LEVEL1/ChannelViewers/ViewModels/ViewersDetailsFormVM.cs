using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChannelViewers.ViewModels
{
    public class ViewersDetailsFormVM: ViewModelBase
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private bool _isSubscribed;

       
        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set { _isSubscribed = value; }
        }

        private bool isMember;

        public bool IsMember
        {
            get { return isMember; }
            set { isMember = value; }
        }

        public bool CanSubmit => string.IsNullOrEmpty(_username);
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ViewersDetailsFormVM(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

        ~ViewersDetailsFormVM()
        {
            Trace.WriteLine("dtor", this.GetType().Name);
        }
    }
}
