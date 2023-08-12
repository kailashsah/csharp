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
    /// Interaction logic for doubleAnimationFrm.xaml
    /// </summary>
    public partial class doubleAnimationFrm : Window
    {
        public doubleAnimationFrm()
        {
            InitializeComponent();
        }


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Storyboard res1 = (Storyboard)this.Resources["Storyboard1"];
            Object res2 = (res1 as Storyboard).Children[0];
            
            res1.Begin();
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            Storyboard res1 = (Storyboard)this.Resources["Storyboard1"];
            Object res2 = (res1 as Storyboard).Children[0];
            res1.Stop();

        }















        private void angleAni_Completed(object sender, EventArgs e)
        {
            //MessageBox.Show("a");
        }

        private void angleAni_CurrentStateInvalidated(object sender, EventArgs e)
        {
            //MessageBox.Show("CurrentStateInvalidated");
        }

        private void angleAni_CurrentGlobalSpeedInvalidated(object sender, EventArgs e)
        {
            //MessageBox.Show("CurrentGlobalSpeedInvalidated");
        }
    }
}
