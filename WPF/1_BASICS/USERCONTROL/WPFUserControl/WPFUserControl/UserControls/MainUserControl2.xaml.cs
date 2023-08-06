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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFUserControl.UserControls
{
    /// <summary>
    /// Interaction logic for MainUserControl2.xaml
    /// </summary>
    public partial class MainUserControl2 : UserControl
    {        
        public MainUserControl2()
        {
            InitializeComponent();
        }
        TabItem _tabUserPage;
        private void BtnSubUser1_Click(object sender, RoutedEventArgs e)
        {
            SubPage.Items.Clear();
            var userControls = new Sub_UserControl1();
            _tabUserPage = new TabItem { Content = userControls };
            SubPage.Items.Add(_tabUserPage);
            SubPage.Items.Refresh();
        }
    }
}
