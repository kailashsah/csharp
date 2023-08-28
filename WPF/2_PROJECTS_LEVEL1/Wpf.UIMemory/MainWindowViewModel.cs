using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Wpf.UIMemory
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int counter = 0;
        public int Counter
        {
            get => counter;
            set
            {
                counter = value;
                Notify(nameof(Counter));
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand OpenCommand { get; set; }
        public MainWindowViewModel()
        {
            OpenCommand = new RelayCommand((param) => CanExecute(param), (param)=>Execute(param)); 

        }

        private bool CanExecute(object param)
        {
            return true;
        }
        private void Execute(object param)
        {
            OpenWindow();
        }
        private void OpenWindow()
        {
            Counter++;

            GameWindow gameWin = new GameWindow(Counter);
            GameTableControl gameCtrl = new GameTableControl(Counter);
            GameWindowVM gameVM = new GameWindowVM();
            //gameWin.DataContext = gameVM;            
            gameCtrl.DataContext = gameVM;
            gameVM.WindowIndex = Counter;

            gameWin.Content = gameCtrl;
            gameWin.Show();
        }
        public void Notify(string arg)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(arg));
            }
        }
    }
}
