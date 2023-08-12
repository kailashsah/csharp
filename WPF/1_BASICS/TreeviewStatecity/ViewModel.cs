using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statecity_treeview
{
    public class ViewModel
    {
        private ObservableCollection<Country> countries;

        public ObservableCollection<Country> Countries
        {
            get { return countries; }
            set { countries = value; }
        }

        public ViewModel()
        {
            countries = new ObservableCollection<Country>();
            ObservableCollection<State> states_india = new ObservableCollection<State>();
            ObservableCollection<State> cities_Maharastra = new ObservableCollection<State>();
            cities_Maharastra.Add(new State() { Name = "Mumbai" });
            cities_Maharastra.Add(new State() { Name = "Pune" });
            cities_Maharastra.Add(new State() { Name = "Nagpur" });
            cities_Maharastra.Add(new State() { Name = "Thane" });
            ObservableCollection<State> cities_karnataka = new ObservableCollection<State>();
            cities_karnataka.Add(new State() { Name = "Bangalore" });
            cities_karnataka.Add(new State() { Name = "Mysore" });
            cities_karnataka.Add(new State() { Name = "Bidar" });
            cities_karnataka.Add(new State() { Name = "Belgaum" });


            states_india.Add( new State() { Name = "Karnataka", States = cities_karnataka  });
            states_india.Add(new State() { Name = "Maharastra", States = cities_Maharastra });
            countries.Add(new Country() { Name = "India", States = states_india });
        }
    }
}
