//using Microsoft.Practices.Prism.PubSubEvents;
using Prism.Events;
using prism_basic.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prism_basic.ViewModels
{
    class PersonViewModel : INotifyPropertyChanged
    {
        private IEventAggregator iEventAggregator;
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                // Publish event.
                this
                    .iEventAggregator
                    .GetEvent<PubSubEvent<string>>()
                    .Publish(this.Name);
                this.NotifyPropertyChanged("Name");
            }
        }

        public PersonViewModel(IEventAggregator iEventAggregator)
        {
            this.iEventAggregator =  iEventAggregator;
            
        }
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
