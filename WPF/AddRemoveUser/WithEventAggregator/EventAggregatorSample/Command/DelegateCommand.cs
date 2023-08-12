using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventAggregatorSample
{
    public class DelegateCommand : ICommand
    {
        private Predicate<object> predicate;
        private Action<object> action;

        public DelegateCommand(Predicate<object> predicate, Action<object> action)
        {
            this.predicate = predicate;
            this.action = action;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return predicate(parameter);
        }

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
