//using Microsoft.Practices.Prism.PubSubEvents;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prism_basic.ViewModels
{
    class PersonDetailsViewModel : INotifyPropertyChanged
    {
        private IEventAggregator iEventAggregator;
        public event PropertyChangedEventHandler PropertyChanged;

        private string name_details;

        public string NameDetails
        {
            get { return name_details; }
            set
            {
                name_details = value;
                //this.NotifyPropertyChanged("NameDetails");
                PropertyChanged(this, new PropertyChangedEventArgs("NameDetails"));



            }
        }

        public PersonDetailsViewModel(IEventAggregator iEventAggregator)
        {
            this.iEventAggregator = iEventAggregator;
            SubscriptionToken subscriptionToken =
                                    this
                                        .iEventAggregator
                                        .GetEvent<PubSubEvent<string>>()
                                        .Subscribe((name_d) =>
                                        {
                                            this.NameDetails = name_d;
                                        });
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
