using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WithDependencyInjection
{
    public class MainWindowViewModel 
    {
        private readonly ILifetimeScope lifetimeScope;
        public INotificationListViewModel NotificationListViewModel { get; set; } 
        public IUserListViewModel UserListViewModel { get; set; }

        public ICommand CreateUserCommand { get; set; }

        public MainWindowViewModel(ILifetimeScope lifetimeScope, IUserListViewModel userListViewModel, INotificationListViewModel notificationListViewModel)
        {
            UserListViewModel = userListViewModel;
            NotificationListViewModel = notificationListViewModel;
            CreateUserCommand = new DelegateCommand((x) => true, CreateUser);
            this.lifetimeScope = lifetimeScope;
        }

        private void CreateUser(object obj)
        {
            var userListViewModel = lifetimeScope.Resolve<IUserListViewModel>();
            var notificationListViewModel = lifetimeScope.Resolve<INotificationListViewModel>();
            UserModelDialog userModelDialog = new UserModelDialog(null, userListViewModel, notificationListViewModel);
            userModelDialog.ShowDialog();
        }
    }

}
