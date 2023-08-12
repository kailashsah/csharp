using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserListDemo
{
    public class UserModel : INotifyPropertyChanged
    {
        private static int staticId = 0;
        public int Id { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(nameof(Name)); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged(nameof(Age)); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public static int GetNewId()
        {
            staticId++;
            return staticId;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
