using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WithViewModelLocator
{
    public class UserListViewModel : IUserListViewModel
    {
        public ICommand RemoveCommand { get; set; }
        public ICommand EditCommand { get; set; }


        public ObservableCollection<UserModel> Users { get; set; } = new ObservableCollection<UserModel>();
        public UserListViewModel()
        {
            RemoveCommand = new DelegateCommand((x) => true, RemoveUser);
            EditCommand = new DelegateCommand((x) => true, EditUser);
        }

        public bool AddUser(UserModel userModel)
        {
            var model = userModel;
            if (model != null)
            {
                Users.Add(new UserModel()
                {
                    Id = UserModel.GetNewId(),
                    Name = model.Name,
                    Age = model.Age,
                });

                return true;
            }

            return false;
        }

        public bool UpdateUser(UserModel userModel)
        {
            var model = userModel;
            if (model != null)
            {
                if (model.Id != 0)
                {
                    var existing = Users.FirstOrDefault(x => x.Id == model.Id);
                    if (existing != null)
                    {
                        existing.Age = model.Age;
                        existing.Name = model.Name;
                        return true;
                    }
                }
            }

            return false;
        }

        private void RemoveUser(object obj)
        {
            if (obj is UserModel userModel)
            {
                var result = Users.Remove(userModel);
                if (result)
                {
                    BasicViewModelLocator.NotificationListViewModel.AddNotification(new NotificationModel()
                    {
                        ActionType = ActionType.Deleted,
                        Message = $"User {userModel.Name} removed."
                    });  
                }
            }
        }


        private void EditUser(object obj)
        {
            UserModelDialog userModelDialog = new UserModelDialog(obj as UserModel);
            userModelDialog.ShowDialog();
        }

    }
}
