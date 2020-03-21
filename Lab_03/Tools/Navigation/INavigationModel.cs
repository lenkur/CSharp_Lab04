namespace KMA.CSharp2020.Lab03.Tools.Navigation
{
    internal enum ViewType
    {
        LogIn,
        UserList
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
