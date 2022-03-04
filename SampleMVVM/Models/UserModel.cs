using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVM.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public string ID { get; set; }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;               
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private bool _sex;
        public bool Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }
        private DateTime _dob;
        public DateTime DateOfBirth
        {
            get { return _dob; }
            set
            {
                _dob = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public string Name { get { return FirstName + " " + MiddleName + " " + LastName; } }
    }
}
