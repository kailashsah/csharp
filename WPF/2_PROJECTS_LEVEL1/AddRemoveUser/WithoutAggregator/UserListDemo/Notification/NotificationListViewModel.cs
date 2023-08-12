using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserListDemo
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

        //private void UserUpdated(UserUpdatedEventArgs obj)
        //{
        //    Notifications.Add(new NotificationModel()
        //    {
        //        ActionType = ActionType.Updated,
        //        Message = $"User {obj.Payload.Name} updated."
        //    });
        //}

        //private void UserRemoved(UserRemovedEventArgs obj)
        //{
        //    Notifications.Add(new NotificationModel()
        //    {
        //        ActionType = ActionType.Deleted,
        //        Message = $"User {obj.Payload.Name} removed."
        //    });
        //}
        //private void UserCreated(UserCreatedEventArgs obj)
        //{
        //    Notifications.Add(new NotificationModel()
        //    {
        //        ActionType = ActionType.Created,
        //        Message = $"User {obj.Payload.Name} created."
        //    });
        //}
    }
}
