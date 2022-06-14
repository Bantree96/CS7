using System.Windows;

namespace Bitmap_Draw
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainViewModel mainViewModel = new MainViewModel();
            InitializeComponent();
            this.DataContext = mainViewModel;
        }
    }
}
