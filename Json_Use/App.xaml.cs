﻿using Json_Use.ViewModels;
using System.Windows;

namespace Json_Use
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWindow;
        private MainViewModel _mainViewModel;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _mainViewModel = new MainViewModel();
            _mainWindow = new MainWindow(_mainViewModel);

            _mainWindow.Show();

        }
    }
}
