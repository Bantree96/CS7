using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeOut_Reset.ViewModels;

namespace TimeOut_Reset
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

            // 바인딩을 위한 권한
            this.DataContext = _mainViewModel;

            InitializeComponent();
        }

        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Start();
        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            _mainViewModel.Stop();
        }
    }
}
