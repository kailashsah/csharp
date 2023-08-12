using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorSample
{
    internal class NotificationListViewModel
    {
        public ObservableCollection<NotificationModel> Notifications { get; set; } = new ObservableCollection<NotificationModel>();
        public NotificationListViewModel()
        {
            EventManager.Instance.Subscribe<UserCreatedEvent, UserCreatedEventArgs>(UserCreated);
            EventManager.Instance.Subscribe<UserRemovedEvent, UserRemovedEventArgs>(UserRemoved);
            EventManager.Instance.Subscribe<UserUpdatedEvent, UserUpdatedEventArgs>(UserUpdated);
        }

        private void UserUpdated(UserUpdatedEventArgs obj)
        {
            Notifications.Add(new NotificationModel()
            {
                ActionType = ActionType.Updated,
                Message = $"User {obj.Payload.Name} updated."
            });
        }

        private void UserRemoved(UserRemovedEventArgs obj)
        {
            Notifications.Add(new NotificationModel()
            {
                ActionType = ActionType.Deleted,
                Message = $"User {obj.Payload.Name} removed."
            });
        }
        private void UserCreated(UserCreatedEventArgs obj)
        {
            Notifications.Add(new NotificationModel()
            {
                ActionType = ActionType.Created,
                Message = $"User {obj.Payload.Name} created."
            });
        }
    }
}
