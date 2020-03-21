using KMA.CSharp2020.Lab03.Tools.Managers;
using KMA.CSharp2020.Lab03.Tools.Navigation;
using System;
using System.Collections.ObjectModel;

namespace KMA.CSharp2020.Lab03.ViewModels
{
    class UserListViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<Person> _users;

        private RelayCommand<object> _backToLogInCommand;

        public UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }
        #endregion

        #region Properties
        public ObservableCollection<Person> Users
        {
            get { return _users; }
            private set
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand<Object> BackToLogInCommand
        {
            get { return _backToLogInCommand ?? (_backToLogInCommand = new RelayCommand<object>(BackToLogInCommandImplementation, o => true)); }
        }

        private void BackToLogInCommandImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.LogIn);
        }
        #endregion
    }
}
