using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserListDemo
{
    public interface IMainWindowViewModel
    {
        INotificationListViewModel NotificationListViewModel { get; set; }
        IUserListViewModel UserListViewModel { get; set; }  
    }

    public interface INotificationListViewModel
    {
        bool AddNotification(NotificationModel notificationModel);
    }

    public interface IUserListViewModel
    {
        bool AddUser(UserModel userModel);
        bool UpdateUser(UserModel userModel);
    }
}
