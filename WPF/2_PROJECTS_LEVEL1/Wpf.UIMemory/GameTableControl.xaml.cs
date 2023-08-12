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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf.UIMemory
{
    /// <summary>
    /// Interaction logic for GameTableControl.xaml
    /// </summary>
    public partial class GameTableControl : UserControl
    {
        public GameTableControl(int tableCounter)
        {
            InitializeComponent();
            TableCounter = tableCounter;
        }
        ~GameTableControl()
        {
            Debug.WriteLine($"Deconstruction {TableCounter}", GetType().Name);
        }

        public int TableCounter { get; }
    }
}
