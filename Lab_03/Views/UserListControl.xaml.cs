using KMA.CSharp2020.Lab03.Tools.Navigation;
using KMA.CSharp2020.Lab03.ViewModels;
using System.Windows.Controls;

namespace KMA.CSharp2020.Lab03.Views
{
    /// <summary>
    /// Interaction logic for UserListControl.xaml
    /// </summary>
    public partial class UserListControl : UserControl, INavigatable
    {
        public UserListControl()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();
        }
    }
}
