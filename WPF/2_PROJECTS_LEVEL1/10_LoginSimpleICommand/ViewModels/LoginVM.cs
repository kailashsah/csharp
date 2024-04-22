using SimpleMVVMApp.Commands;
using SimpleMVVMApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleMVVMApp.ViewModels
{
    public class LoginVM : ViewModelBase
    {
        public User user;
        private string userName;
        private string password;
        public ICommand LoginCommand { get;  }

        public LoginVM()
        {
            user = new User();
            LoginCommand = new RelayCommand((param) => LoggIn(param), (param) => CanExecute(param));
        }

        private bool CanExecute(object param)
        {
            var passwordCtrl = param as PasswordBox;
            if(string.IsNullOrWhiteSpace(passwordCtrl?.Password) 
                || string.IsNullOrEmpty(UserName)
                )
            {
                return false;
            }
            return true ;
        }

        private void LoggIn(object param)
        {
            MessageBox.Show($"{UserName} user logged-in!");
        }

        public string UserName
        {
            get => user.UserName;
            set
            {
                user.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }

        }

        public string Password { 
            get => user.Password;
            set
            {
                user.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        
    }
}
