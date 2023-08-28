using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf.UIMemory
{
    public class RelayCommand : ICommand
    {
        private Func<object, bool> canExecute;
        private Action<object> execute;

        public RelayCommand(Func<object, bool> canExecute, Action<object> executeAction)
        {
            this.execute    = executeAction;
            this.canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }

        
    }
}
