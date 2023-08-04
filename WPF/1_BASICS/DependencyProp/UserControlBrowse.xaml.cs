using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace usercontrol_text
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlBrowse : UserControl
    {

        public static readonly DependencyProperty BlockNameProperty =
            DependencyProperty.Register("BlockName", typeof(string), typeof(UserControlBrowse),
                new PropertyMetadata("", SetBlockNameChanged));

        private static void SetBlockNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControlBrowse control1 = (UserControlBrowse)d;
            var newValue = (string)e.NewValue;

            if (control1 != null)
            {
                control1.CTextBlock.Text = string.IsNullOrEmpty(newValue) ? (string)e.OldValue : newValue;
            }
        }

        public string BlockName
        {
            get { return (string)GetValue(BlockNameProperty); }
            set
            {
                SetValue(BlockNameProperty, value);
                CTextBlock.Text = value;
            }
        }
        private Type _T;
        public Type T
        {
            set { _T = value; }
            get { return _T; }
        }
        public enum Type { File, Folder }
        public UserControlBrowse()
        {
            InitializeComponent();
        }
        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            if (_T == Type.File)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                    ofd.ShowDialog();
                    SetValue(BlockNameProperty, ofd.FileName);
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                CTextbox.Text = fbd.SelectedPath;
            }
        }
       
    }
    /*
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public string Accessories
        {
            get { return (string)GetValue(AccessoriesProperty); }
            set { 
                SetValue(AccessoriesProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for Accessories.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccessoriesProperty =
            DependencyProperty.Register("Accessories", typeof(string), typeof(UserControl1), new PropertyMetadata("", UserControl1Changed));

        private static void UserControl1Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            return;
        }
    }
    */
}
