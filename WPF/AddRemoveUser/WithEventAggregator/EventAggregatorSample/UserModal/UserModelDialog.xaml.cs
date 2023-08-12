using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EventAggregatorSample
{
    /// <summary>
    /// Interaction logic for UserModelDialog.xaml
    /// </summary>
    public partial class UserModelDialog : Window , IClose
    {
        public UserModelDialog(UserModel userModel)
        {
            InitializeComponent();
            this.DataContext = new UserModalViewModel(userModel, this);
        }

        public void CloseWindow()
        {
            this.Close();
        }
    }
}
