using KMA.CSharp2020.Lab03.Views;
using System;

namespace KMA.CSharp2020.Lab03.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner) { }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.LogIn:
                    ViewsDictionary.Add(viewType, new LogInControl());
                    break;
                case ViewType.UserList:
                    ViewsDictionary.Add(viewType, new UserListControl());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}