using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WithViewModelLocator
{
    public class MainWindowViewModel 
    {
        public ICommand CreateUserCommand { get; set; }

        public MainWindowViewModel()
        {
            CreateUserCommand = new DelegateCommand((x) => true, CreateUser);
        }

        private void CreateUser(object obj)
        {
            UserModelDialog userModelDialog = new UserModelDialog(null);
            userModelDialog.ShowDialog();
        }
    }
}
