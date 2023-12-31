﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace usercontrol_text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public string textBoxMain;
        public string TextBoxMain
        {
            get => textBoxMain;
            set
            {
                textBoxMain = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TextBoxMain)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
