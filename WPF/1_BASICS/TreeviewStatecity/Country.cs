using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statecity_treeview
{
    public class Country
    {
        public string Name { get; set; }
        public ObservableCollection<State> States { get; set; }
    }

    public class State
    {
      public string Name { get; set; }
      public ObservableCollection<State> States { get; set; }

    }
    public class City
    {
        public string Name { get; set; }
        

    }
}
