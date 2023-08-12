using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WithDependencyInjection
{
    internal class UserModalViewModel : INotifyPropertyChanged
    {

        private int age;
        private readonly UserModel _userModel;
        private readonly IClose _closableWindow;
        private readonly IUserListViewModel userListViewModel;
        private readonly INotificationListViewModel notificationListViewModel;
        private readonly bool _isInEditMode = false;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }

        public string OkButtonContent { get; set; }

        public ICommand CreateUpdateCommand { get; set; }

        public UserModalViewModel(UserModel userModel, IClose closableWindow, IUserListViewModel userListViewModel, INotificationListViewModel notificationListViewModel)
        {
            CreateUpdateCommand = new DelegateCommand((x) => true, CreateOrUpdate);
            _userModel = userModel;
            _closableWindow = closableWindow;
            this.userListViewModel = userListViewModel;
            this.notificationListViewModel = notificationListViewModel;
            _isInEditMode = userModel != null;
            OkButtonContent = _isInEditMode ? "Update" : "Create";
            _userModel = userModel;

            if (_isInEditMode)
            {
                Name = userModel.Name;
                Age = userModel.Age;
            }
        }

        private void CreateOrUpdate(object obj)
        {
            if (_isInEditMode)
            {
                var result = userListViewModel.UpdateUser(new UserModel()
                {
                    Name = Name,
                    Age = Age,
                    Id = _userModel.Id
                });

                if (result)
                {
                    notificationListViewModel.AddNotification(new NotificationModel()
                    {
                        ActionType = ActionType.Updated,
                        Message = $"User {Name} updated."
                    });
                }
            }
            else
            {
                var result = userListViewModel.AddUser(new UserModel()
                {
                    Name = Name,
                    Age = Age,
                });

                if (result)
                {
                    notificationListViewModel.AddNotification(new NotificationModel()
                    {
                        ActionType = ActionType.Created,
                        Message = $"User {Name} created."
                    });
                }
            }

            _closableWindow?.CloseWindow();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
