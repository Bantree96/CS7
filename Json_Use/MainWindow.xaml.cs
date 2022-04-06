using Json_Use.ViewModels;
using System.Windows;

namespace Json_Use
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainViewModel;
        public MainWindow(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            InitializeComponent();

            this.DataContext = _mainViewModel;
        }
    }
}
