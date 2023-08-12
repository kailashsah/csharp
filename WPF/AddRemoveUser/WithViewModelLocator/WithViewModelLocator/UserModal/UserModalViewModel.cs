using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WithViewModelLocator
{
    internal class UserModalViewModel : INotifyPropertyChanged
    {

        private int age;
        private readonly UserModel _userModel;
        private readonly IClose _closableWindow;
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

        public UserModalViewModel(UserModel userModel, IClose closableWindow)
        {
            CreateUpdateCommand = new DelegateCommand((x) => true, CreateOrUpdate);
            _userModel = userModel;
            _closableWindow = closableWindow;
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
                var result = BasicViewModelLocator.UserListViewModel.UpdateUser(new UserModel()
                {
                    Name = Name,
                    Age = Age,
                    Id = _userModel.Id
                });

                if (result)
                {
                    BasicViewModelLocator.NotificationListViewModel.AddNotification(new NotificationModel()
                    {
                        ActionType = ActionType.Updated,
                        Message = $"User {Name} updated."
                    });
                }
            }
            else
            {
                var result = BasicViewModelLocator.UserListViewModel.AddUser(new UserModel()
                {
                    Name = Name,
                    Age = Age,
                });

                if (result)
                {
                    BasicViewModelLocator.NotificationListViewModel.AddNotification(new NotificationModel()
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
