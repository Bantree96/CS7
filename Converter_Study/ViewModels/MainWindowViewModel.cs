using Converter_Study.Datas;
using Prism.Mvvm;

namespace Converter_Study.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // Field
        private InspectionState _inspectionState;
        private string _text;

        // Property
        public InspectionState InspectionState { get { return _inspectionState; } set { SetProperty(ref _inspectionState, value); } }
        public string Text { get { return _text; } set { SetProperty(ref _text, value); } }

        public MainWindowViewModel()
        {
            InspectionState = InspectionState.STOPPED;
            Text = "123";
        }
    }
}
