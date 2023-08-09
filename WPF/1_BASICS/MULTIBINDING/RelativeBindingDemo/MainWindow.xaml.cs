﻿using System;
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

namespace BindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }

        private void Btn_StringFormat_Click(object sender, RoutedEventArgs e)
        {
            //StringFormatAndMultiBinding obj = new StringFormatAndMultiBinding();
            //obj.Show();



        }
    }

    public class ViewModel
    {
        public string Text { get; set; } = "Hello From ViewModel";

        public string FirstName { get; set; } = "Virat";
        public string LastName { get; set; } = "Kohli";
    }
}
