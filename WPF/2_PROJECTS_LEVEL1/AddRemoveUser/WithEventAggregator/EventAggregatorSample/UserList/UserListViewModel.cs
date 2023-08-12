using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EventAggregatorSample
{
    public class UserListViewModel
    {
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }


        private bool internalDelete = false;


        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();
        public UserListViewModel()
        {
            RemoveCommand = new DelegateCommand((x) => true, RemoveUser);
            EditCommand = new DelegateCommand((x) => true, EditUser);
            EventManager.Instance.Subscribe<UserCreatedEvent, UserCreatedEventArgs>(UserCreated);
            EventManager.Instance.Subscribe<UserRemovedEvent, UserRemovedEventArgs>(UserRemoved);
            EventManager.Instance.Subscribe<UserUpdatedEvent, UserUpdatedEventArgs>(UserUpdated);
        }

        private void UserUpdated(UserUpdatedEventArgs obj)
        {
            var model = obj.Payload;
            if (model != null)
            {
                var existing = Users.FirstOrDefault(x => x.Id == model.Id);
                if(existing != null)
                {
                    existing.Age = model.Age;
                    existing.Name = model.Name;
                }
            }
        }

        private void UserRemoved(UserRemovedEventArgs obj)
        {
            if (!internalDelete)
                Users.Remove(obj.Payload);
        }

        private void RemoveUser(object obj)
        {
            if (Users.Remove(obj as UserModel))
            {
                internalDelete = true;
                EventManager.Instance.Publish<UserRemovedEvent, UserRemovedEventArgs>(new UserRemovedEventArgs()
                {
                    Payload = obj as UserModel
                });
                internalDelete = false;
            }
        }


        private void EditUser(object obj)
        {
            UserModelDialog userModelDialog = new UserModelDialog(obj as UserModel);
            userModelDialog.ShowDialog();
        }



        private void UserCreated(UserCreatedEventArgs obj)
        {
            Users.Add(new UserModel()
            {
                Id = obj.Payload.Id,
                Name = obj.Payload.Name,
                Age = obj.Payload.Age,
            });
        }
    }
}
