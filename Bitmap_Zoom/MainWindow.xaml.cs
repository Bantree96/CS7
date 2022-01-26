using Bitmap_Zoom.ViewModels;
using System.Windows;

namespace Bitmap_Zoom
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel _mainViewModel;

        public MainWindow(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            this.DataContext = _mainViewModel;
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Zoom();
        }
    }
}
