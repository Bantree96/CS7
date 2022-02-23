﻿using ObservableCollection_Study.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ObservableCollection_Study
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
