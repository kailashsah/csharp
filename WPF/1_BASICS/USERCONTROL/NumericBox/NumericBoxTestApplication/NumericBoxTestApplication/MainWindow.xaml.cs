using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NumericBoxTestApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericBox_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (nb.Value > 50) nb.Foreground = Brushes.OrangeRed;
            else if (nb.Value < -50) nb.Foreground = Brushes.DodgerBlue;
            else nb.Foreground = Brushes.Black;
        }
    }
}
