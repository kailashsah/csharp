using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithViewModelLocator
{
    internal static class BasicViewModelLocator
    {
        private static MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

        public static MainWindowViewModel MainWindowViewModel
        {
            get { return mainWindowViewModel; }
        }

        private static INotificationListViewModel notificationListViewModel = new NotificationListViewModel();

        public static INotificationListViewModel NotificationListViewModel
        {
            get { return notificationListViewModel; }
        }

        private static IUserListViewModel userListViewModel = new UserListViewModel();

        public static IUserListViewModel UserListViewModel
        {
            get { return userListViewModel; }
        }

    }
}
