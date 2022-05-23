using Converter_Study.ViewModels;
using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;

namespace Converter_Study
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
        }
    }
}
