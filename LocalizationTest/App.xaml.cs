using LocalizationTest.Services;
using LocalizationTest.ViewModels;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LocalizationTest
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            ResourcesInit();

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<LocalizationService>();

            Container.Resolve<LocalizationService>();

        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            ViewModelLocationProvider.Register<MainWindow, MainWindowViewModel>();
        }

        /// <summary>
        /// Prism은 모듈별로 Resource를 관리하기 때문에 App단에서 Resource를 등록 할 수 없음.
        /// 이렇게 다른 부분에서 Resource를 생성하고 Merged해줘야함
        /// </summary>
        public void ResourcesInit()
        {
            // Register the module-specific resources
            var resources = new ResourceDictionary();
            resources.Source = new Uri("/Resources/CoreResources.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(resources);
        }
       
    }
}
