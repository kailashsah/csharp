using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Wpf.UIMemory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Parent obj = new Parent(); // case 2.
     

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
                
        }

        private int counter = 0;

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            //Thread th = new Thread(ThreadMethod);
            //th.IsBackground = false;
            //th.Start();
            //
            MethodMemLeak(); // case 1.
            // 
          
            // 
            if (counter == 4)
            {
                childlist.Clear(); // case 1. // free up the child objects
            }

            //obj.child = null; // case 2. // if child got free if parent is still occupied
        }

        

        private void FreeMemory_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }


        Child child;
        List<Child> childlist = new List<Child>();


        public void MethodMemLeak()
        {
            Parent obj = new Parent();
            child = obj.child;
            childlist.Add(obj.child);
            obj = null;  // not req ; free up parent objects
        }
       
    }

    #region memleak
    public class Parent
    {
        private static int counter = 0;
        public int instancePos;
        public Child child = new Child();
        public Parent()
        {
            counter++;
            this.instancePos = counter;
            child.Counter = instancePos;
        }
        ~Parent()
        {
            Trace.WriteLine($"Parent dtor : {this.instancePos}");
        }
    }

    public class Child
    {
        private int counter;
        public Child()
        {
            
        }
        ~Child()
        {
            Trace.WriteLine($"Child dtor : {Counter}");
        }

        public int Counter { get => counter; set => counter = value; }
    }
    #endregion
}
