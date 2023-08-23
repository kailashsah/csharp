using System;
using System.Collections.Generic;
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
        private int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            //Thread th = new Thread(ThreadMethod);
            //th.IsBackground = false;
            //th.Start();
            MethodMemLeak(); // case 1.

            //

            counter++;

            GameWindow gameWin = new GameWindow(counter);
            GameTableControl gameCtrl = new GameTableControl(counter);
            GameWindowVM gameVM = new GameWindowVM();
            //gameWin.DataContext = gameVM;            
            gameCtrl.DataContext = gameVM;
            gameVM.WindowIndex = counter;

            gameWin.Content = gameCtrl;
            gameWin.Show();

            if (counter == 4)
            {
                childlist.Clear(); // case 1. // free up the child objects
            }

            //obj.child = null; // case 2. // if child got free if parent is still occupied

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
