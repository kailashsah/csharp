using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMVVMApp.Commands
{
    public class RelayCommand : ICommand
    {

        private readonly Action<object> _executionAction;
        private readonly Func<object, bool> _canExecuteMethod;
        public event EventHandler CanExecuteChanged
        {

            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }
        public RelayCommand(Action<object> executionAction, Func<object, bool> canExecuteMethod)
        {
            _executionAction = executionAction;
            _canExecuteMethod = canExecuteMethod;
        }
        public bool CanExecute(object parameter)
        {
            //return true;
            return _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executionAction(parameter);
        }
    }
}
