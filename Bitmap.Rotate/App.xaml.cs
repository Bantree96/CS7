using Bitmap.Rotate.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bitmap.Rotate
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : Application
	{
		private MainWindow _mainWindow;
		private MainWindowViewModel _mainWindowViewModel;

		private void Application_Startup(object sender, StartupEventArgs e)
		{
			_mainWindowViewModel = new MainWindowViewModel();
			_mainWindow = new MainWindow(_mainWindowViewModel);

			_mainWindow.Show();
		}
	}
}
