using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserListDemo
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public ICommand CreateUserCommand { get; set; }
        public INotificationListViewModel NotificationListViewModel { get; set; } = new NotificationListViewModel();
        public IUserListViewModel UserListViewModel { get; set; }

        public MainWindowViewModel()
        {
            CreateUserCommand = new DelegateCommand((x) => true, CreateUser);
            UserListViewModel = new UserListViewModel(this);
        }

        private void CreateUser(object obj)
        {
            UserModelDialog userModelDialog = new UserModelDialog(this,null);
            userModelDialog.ShowDialog();
        }
    }
}
