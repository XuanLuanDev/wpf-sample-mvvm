using SampleMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleMVVM.ViewModel
{
    public class MainWindowViewModel:BaseViewModel
    {
        private ObservableCollection<UserModel> _lstUsers;
        public ObservableCollection<UserModel> ListUsers {
            get { return _lstUsers; }
            set { _lstUsers = value;
                OnPropertyChanged();
            }
        }
        private UserModel _currentUser;
        public UserModel CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }
        public bool IsFeMale
        {
            get { return !_currentUser.Sex; }
            set
            {
                _currentUser.Sex = !value;
                OnPropertyChanged();
            }
        }
        private bool _isUpdate = false;
        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }
        private UserModel _selectUser;
        public UserModel SelectUser
        {
            get { return _selectUser; }
            set
            {
                _selectUser = value;
                if (value != null)
                {
                    CurrentUser = value;
                    IsUpdate = true;
                }
                OnPropertyChanged();
            }
        }
        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public MainWindowViewModel()
        {
            _lstUsers = new ObservableCollection<UserModel>();
            _currentUser = new UserModel();
            NewCommand = new RelayCommand<string>((p) => { return true; }, (p) => { _isUpdate = false; CurrentUser = new UserModel(); });
            SaveCommand = new RelayCommand<string>((p) => { return true; }, (p) => {
                if (!IsUpdate)
                {
                    AddUser();
                    return;
                }
                Update();
            });
            DeleteCommand = new RelayCommand<string>((p) => { return true; }, (p) => {
                ListUsers.Remove(CurrentUser);
                _isUpdate = false; CurrentUser = new UserModel();
                OnPropertyChanged();
            });
        }
        public void AddUser()
        {   CurrentUser.ID = Guid.NewGuid().ToString("N");
            ListUsers.Add(CurrentUser);
            OnPropertyChanged();
        }
        public void Update()
        {
            var user = ListUsers.FirstOrDefault(t => t.ID == CurrentUser.ID);
            int index = ListUsers.IndexOf(user);
            ListUsers.Remove(user);
            user.LastName = CurrentUser.LastName;
            user.FirstName = CurrentUser.FirstName;
            user.MiddleName = CurrentUser.MiddleName;
            user.Sex = CurrentUser.Sex;
            user.DateOfBirth = CurrentUser.DateOfBirth;
            ListUsers.Insert(index, user);


        }
    }
}
