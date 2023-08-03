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
using System.Windows.Shapes;

namespace Wpf.UIMemory
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    /// 

    public partial class GameWindow : Window
    {
        private readonly int _windowIndex;
        dynamic listContact;

        public GameWindow(int windowIndex)
        {
            _windowIndex = windowIndex;
            //Methodx();
            InitializeComponent();
           
        }
        ~GameWindow()
        {

            Debug.WriteLine($"Deconstruction {_windowIndex}", GetType().Name);
        }


        public void Methodx()
        {
            listContact = Enumerable.Repeat(new Contact(), 5000);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //DataContext = this; // give binding error of WindowIndex property
            ((UserControl)this.Content).DataContext = null;
            //DataContext = null;
        }
    }
    /// <summary>
    /// 
    /// </summary>

    public class Contact
    {
        private string name = "abcdefghijklmnopqrstuvwxyz_abcdefghijklmnopqrstuvwxyz_abcdefghijklmnopqrstuvwxyz_abcdefghijklmnopqrstuvwxyz_abcdefghijklmnopqrstuvwxyz_abcdefghijklmnopqrstuvwxyz_abcdefghijklmnopqrstuvwxyz";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }

}
