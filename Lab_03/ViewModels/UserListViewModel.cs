using KMA.CSharp2020.Lab03.Tools.Managers;
using KMA.CSharp2020.Lab03.Tools.Navigation;
using System;

namespace KMA.CSharp2020.Lab03.ViewModels
{
    class UserListViewModel : BaseViewModel
    {
        #region Fields

        private RelayCommand<object> _backToLogInCommand;
        #endregion

        public RelayCommand<Object> BackToLogInCommand
        {
            get { return _backToLogInCommand ?? (_backToLogInCommand = new RelayCommand<object>(BackToLogInCommandImplementation, o => true)); }
        }

        private void BackToLogInCommandImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.LogIn);
        }
    }
}
