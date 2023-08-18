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
            ThreadMethod();
            Trace.WriteLine(child.ToString());
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
                childlist.Clear();
            }
        }

       

        Child child;
        List<Child> childlist = new List<Child>();

        public void ThreadMethod()
        {
            Parent obj = new Parent();
            child = obj.child;
            childlist.Add(obj.child);
            obj = null;
        }
    }

    #region memleak
    public class Parent
    {
        public Child child = new Child();
        ~Parent()
        {
            Trace.WriteLine("Parent dtor");
        }
    }

    public class Child
    {
        ~Child()
        {
            Trace.WriteLine("Child dtor");
        }
    }
    #endregion
}
