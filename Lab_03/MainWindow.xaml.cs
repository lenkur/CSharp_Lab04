using KMA.CSharp2020.Lab03.Tools.DataStorage;
using KMA.CSharp2020.Lab03.Tools.Managers;
using KMA.CSharp2020.Lab03.Tools.Navigation;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace KMA.CSharp2020.Lab03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
        SerializedDataStorage _serializedDataStorage;

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            _serializedDataStorage.SaveChanges();
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            _serializedDataStorage = new SerializedDataStorage();
            StationManager.Initialize(_serializedDataStorage);
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.LogIn);
        }
    }
}