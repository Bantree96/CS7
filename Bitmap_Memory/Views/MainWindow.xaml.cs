﻿using Bitmap_Memory.ViewModels;
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

namespace Bitmap_Memory
{
	/// <summary>
	/// MainWindow.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainWindow : Window
	{
		private MainWindowViewModel _viewModel;
		public MainWindow(MainWindowViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			DataContext = viewModel;

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			_viewModel.Run();
		}
	}
}
