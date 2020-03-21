﻿using KMA.CSharp2020.Lab03.Tools.Managers;
using KMA.CSharp2020.Lab03.Tools.Navigation;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace KMA.CSharp2020.Lab03
{
    internal class LogInViewModel : BaseViewModel
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        private int _age;
        private string _westernZodiac;
        private string _chineseZodiac;
        private Person _person;

        #region Commands
        private RelayCommand<object> _calculateCommand;
        private RelayCommand<object> _showAllCommand;
        #endregion
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }
        public int Age
        {
            get { return User == null ? 0 : User.Age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public string WesternZodiac
        {
            get { return User == null ? "" : User.SunSign; }
            set
            {
                _westernZodiac = value;
                OnPropertyChanged();
            }
        }
        public string ChineseZodiac
        {
            get { return User == null ? "" : User.ChineseSign; }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged();
            }
        }
        public string GeneralInformation
        {
            get
            {
                if (User == null) return "";
                string temp = User.IsAdult ? "You are an adult." : "You are not an adult yet.";
                return $"Congratulationas, {Name} {Surname}!\nYour age is {Age} years, since you have born in {BirthDate.Date:D}\n{temp}";
            }
            set { OnPropertyChanged(); }
        }
        public string EmailInformation
        {
            get { return User == null ? "" : $"We will send you details on your e-mail: {Email}"; }
            set { OnPropertyChanged(); }
        }
        private Person User
        {
            get { return _person; }
            //set { _person = new Person(_name, _surname, _email, _birthDate); }
        }
        #endregion

        #region Commands
        public RelayCommand<Object> CalculateCommand
        {
            get { return _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(CommandInmplementation, o => CanExecuteCommandLogIn())); }
        }

        public RelayCommand<Object> ShowAllCommand
        {
            get { return _showAllCommand ?? (_showAllCommand = new RelayCommand<object>(ShowAllImplementation, o => true)); }
        }

        public bool CanExecuteCommandLogIn()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname) &&
                   !string.IsNullOrWhiteSpace(Email);
        }

        private void ShowAllImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.UserList);
        }

        private async void CommandInmplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(1000));
            Calculate();
            LoaderManager.Instance.HideLoader();
        }
        #endregion

        #region Methods
       
        private void Calculate()
        {
            try
            {
                _person = new Person(Name, Surname, Email, BirthDate);
                WesternZodiac = User.SunSign;
                ChineseZodiac = User.ChineseSign;
                ManageOutput();
                if (User.IsBirthday) MessageBox.Show("Happy Birthday!", "Congratulations!", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ManageOutput()
        {
            GeneralInformation = "";
            EmailInformation = "";
            Name = "";
            Surname = "";
            Email = "";
        }
        #endregion
    }
}