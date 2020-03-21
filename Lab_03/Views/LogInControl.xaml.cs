using KMA.CSharp2020.Lab03.Tools.Navigation;
using System.Windows.Controls;

namespace KMA.CSharp2020.Lab03
{
    /// <summary>
    /// Interaction logic for LogInControl.xaml
    /// </summary>
    public partial class LogInControl : UserControl, INavigatable
    {
        public LogInControl()
        {
            InitializeComponent();
            DataContext = new LogInViewModel();
        }
    }
}