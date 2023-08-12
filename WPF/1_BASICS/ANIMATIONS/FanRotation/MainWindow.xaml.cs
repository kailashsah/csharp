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

namespace fan_rotation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //gridAnimation.Duration = new Duration(new TimeSpan(10));

        }

        private void radioZero_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            int rSelection = int.Parse(rb.Content.ToString());
            switch (rSelection)
            {
                case 0:
                    {
                        gridAnimation.Duration = new Duration(new TimeSpan(0));
                        break;
                    }
                case 1:
                    {
                        gridAnimation.Duration = new Duration(new TimeSpan(0,0,5));
                        break;
                    }
                case 2:
                    {
                        gridAnimation.Duration = new Duration(new TimeSpan(0,0,2));
                        break;
                    }
                case 3:
                    {
                        gridAnimation.Duration = new Duration(new TimeSpan(1000));
                        
                        
                        break;
                    }
                    
            }

            storyboardFan.Begin();
        }

    }
}
