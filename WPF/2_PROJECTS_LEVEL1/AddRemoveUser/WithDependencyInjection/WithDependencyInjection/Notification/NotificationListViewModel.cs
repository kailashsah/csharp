using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithDependencyInjection
{
    public class NotificationListViewModel : INotificationListViewModel
    {
        public ObservableCollection<NotificationModel> Notifications { get; set; } = new ObservableCollection<NotificationModel>();
        public NotificationListViewModel()
        {
        }

        public bool AddNotification(NotificationModel notificationModel)
        {
            Notifications.Add(new NotificationModel()
            {
                ActionType = notificationModel.ActionType,
                Message =notificationModel.Message,
            });

            return true;
        }

    }
}
