using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithDependencyInjection.Services
{
    public class WindowService : IWindowService
    {
        private readonly ILifetimeScope lifetimeScope;

        public WindowService(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public void ShowUserModal(UserModel userModel)
        {
            var userListViewModel = lifetimeScope.Resolve<IUserListViewModel>();
            var notificationListViewModel = lifetimeScope.Resolve<INotificationListViewModel>();
            UserModelDialog userModelDialog = new UserModelDialog(userModel, userListViewModel, notificationListViewModel);
            userModelDialog.ShowDialog();
        }
    }

    public interface IWindowService
    {
        void ShowUserModal(UserModel userModel);
    }
}
