using System;
using System.Windows;

using static EventAggregatorSample.MainWindow;

namespace EventAggregatorSample
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            DataContext = new MainWindowViewModel();
            
        }
    }


    
   
}
