using KMA.CSharp2020.Lab03.Tools.Managers;
using KMA.CSharp2020.Lab03.Tools.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace KMA.CSharp2020.Lab03.ViewModels
{
    class UserListViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<Person> _users;
        private Person _selectedPerson;

        #region Commands
        private RelayCommand<object> _backToLogInCommand;
        private RelayCommand<object> _deletePersonCommand;
        #endregion
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
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

        #region Commands
        public RelayCommand<Object> BackToLogInCommand
        {
            get { return _backToLogInCommand ?? (_backToLogInCommand = new RelayCommand<object>(BackToLogInCommandImplementation, o => true)); }
        }
        public RelayCommand<Object> DeletePersonCommand
        {
            get { return _deletePersonCommand ?? (_deletePersonCommand = new RelayCommand<object>(DeletePersonCommandImplementation, o => true)); }
        }

        private void DeletePersonCommandImplementation(object obj)
        {
            MessageBox.Show(SelectedPerson.Guid.ToString());
            if (SelectedPerson == null) return;
            if (MessageBox.Show("Delete Person?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                StationManager.DataStorage.DeletePerson(SelectedPerson);
                Users.Remove(SelectedPerson);
            }
        }

        private void BackToLogInCommandImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.LogIn);
        }
        #endregion
    }
}