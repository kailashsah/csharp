using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using prism_basic.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prism_basic
{
    public class Module : IModule
    {
        public IRegionManager iregionManager_;
        public Module(IRegionManager iregionManager)
        {
            iregionManager_ = iregionManager;
        }
        public void Initialize()
        {
            iregionManager_.RegisterViewWithRegion("Person", typeof (Person));
            iregionManager_.RegisterViewWithRegion("PersonDetails", typeof(PersonDetails));
        }
    }
}
