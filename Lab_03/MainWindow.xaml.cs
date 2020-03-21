using KMA.CSharp2020.Lab03.Tools.DataStorage;
using KMA.CSharp2020.Lab03.Tools.Managers;
using KMA.CSharp2020.Lab03.Tools.Navigation;
using System.Windows;
using System.Windows.Controls;

namespace KMA.CSharp2020.Lab03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            StationManager.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.LogIn);
        }
    }
}
