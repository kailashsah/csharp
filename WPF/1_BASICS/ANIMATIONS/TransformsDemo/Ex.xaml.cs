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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TransformsDemo
{
    /// <summary>
    /// Interaction logic for Ex.xaml
    /// </summary>
    public partial class Ex : Window
    {
        public Ex()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void animatedRectangle_Loaded(object sender, RoutedEventArgs e)
        {
            //myStoryboard.Begin();

            Storyboard res1 = (Storyboard)this.Resources["myst"];
            //Object res2 = (res1 as Storyboard).Children[0];

            res1.Begin();


        }
    }
}
