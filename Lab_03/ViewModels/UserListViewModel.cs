using KMA.CSharp2020.Lab03.Tools.Managers;
using KMA.CSharp2020.Lab03.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace KMA.CSharp2020.Lab03.ViewModels
{
    class UserListViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<Person> _users;
        private Person _selectedPerson;
        private string _textFilter;
        private ObservableCollection<string> _filterByList;
        private string _selectedFilter;

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
        public string TextFilter
        {
            get { return _textFilter; }
            set
            {
                _textFilter = value;
                FilterUsers();
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> FilterByList
        {
            get { return _filterByList; }
            set
            {
                _filterByList = value;
                OnPropertyChanged();
            }
        }
        public string SelectedFilter
        {
            get { return _selectedFilter; }
            set
            {
                _selectedFilter = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            _filterByList = new ObservableCollection<string>();
            FilterByList.Add("Name");
            FilterByList.Add("Surname");
            FilterByList.Add("Email");
            FilterByList.Add("Sun Sign");
            FilterByList.Add("Chinese Sign");
        }

        #region Commands
        public void Update()
        {
            Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

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
            if (SelectedPerson == null) return;
            if (MessageBox.Show("Delete Person?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                StationManager.DataStorage.DeletePerson(SelectedPerson);
                Update();
            }
        }

        private void BackToLogInCommandImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.LogIn);
        }

        private void FilterUsers()
        {
            switch (SelectedFilter)
            {
                case "Name":
                    Users = new ObservableCollection<Person>(
                        from person in StationManager.DataStorage.UsersList
                        where person.Name.Contains(TextFilter)
                        select person);
                    break;
                case "Surname":
                    Users = new ObservableCollection<Person>(
                       from person in StationManager.DataStorage.UsersList
                       where person.Surname.Contains(TextFilter)
                       select person);
                    break;
                case "Email":
                    Users = new ObservableCollection<Person>(
                       from person in StationManager.DataStorage.UsersList
                       where person.Surname.Contains(TextFilter)
                       select person);
                    break;
                case "Sun Sign":
                    Users = new ObservableCollection<Person>(
                        from person in StationManager.DataStorage.UsersList
                        where person.SunSign.Contains(TextFilter)
                        select person);
                    break;
                case "Chinese Sign":
                    Users = new ObservableCollection<Person>(
                       from person in StationManager.DataStorage.UsersList
                       where person.ChineseSign.Contains(TextFilter)
                       select person);
                    break;
            }
        }
        #endregion
    }
}