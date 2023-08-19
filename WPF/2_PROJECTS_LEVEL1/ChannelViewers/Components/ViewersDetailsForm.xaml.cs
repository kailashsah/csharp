using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChannelViewers.Components
{
    /// <summary>
    /// Interaction logic for ViewersDetailsForm.xaml
    /// </summary>
    public partial class ViewersDetailsForm : UserControl
    {
        public ViewersDetailsForm()
        {
            InitializeComponent();
        }
        ~ViewersDetailsForm()
        {
            Trace.WriteLine("dtor", this.GetType().Name);
        }
    }
}
