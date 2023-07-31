using LocalizationTest.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationTest.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private LocalizationService _localizationService;

        private string _title;
        public string Title { get => _title; set => SetProperty(ref _title, value); }

        public DelegateCommand<string> LanguageChangeCommand => new DelegateCommand<string>(OnLanguageChanged);
        

        public MainWindowViewModel(LocalizationService localizationService)
        {
            _localizationService = localizationService;

            //_localizationService = App.Current.Resources["DR"] as LocalizationService;
            _localizationService.LanguageChanged += LanguageChanged;

            // WPF 언어는 기본적으로 en-US인 상태이기 때문에 언어변경을 한번 해줘야 영어로 사용 가능.
            _localizationService.ChangeLanguage("ko-KR");
            _localizationService.ChangeLanguage("en-US");
        }

        private void OnLanguageChanged(string obj)
        {
            _localizationService.ChangeLanguage(obj);
        }

        // 언어 변경됐을 때 ViewModel에서 처리할 내용
        private void LanguageChanged(object sender, string e)
        {
            Title = _localizationService["Title"];
        }
    }
}
