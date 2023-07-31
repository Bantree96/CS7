using LocalizationTest.Resources;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace LocalizationTest.Services
{
    public class LocalizationService : DynamicObject
    {
        public event EventHandler<string> LanguageChanged;

        private readonly ResourceManager _resourceManager;
        private CultureInfo _cultureInfo;

        public LocalizationService()
        {
            _resourceManager = new ResourceManager(typeof(Resource));

        }

        /// <summary>
        /// Property로 호출
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string this[string id]
        {
            get
            {
                if (string.IsNullOrEmpty(id)) return null;
                string str = _resourceManager.GetString(id, _cultureInfo);
                if (string.IsNullOrEmpty(str))
                {
                    str = id;
                }
                return str;
            }
        }

        /// <summary>
        /// 이름으로 호출
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string id = binder.Name;
            string str = _resourceManager.GetString(id, _cultureInfo);
            if (string.IsNullOrEmpty(str))
            {
                str = id;
            }
            result = str;
            return true;
        }

        public void ChangeLanguage(string languageCode)
        {
            _cultureInfo = new CultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = _cultureInfo;
            Thread.CurrentThread.CurrentUICulture = _cultureInfo;

            // 윈도우의 언어코드 변경
            foreach(Window window in Application.Current.Windows.Cast<Window>())
            {
                if (!window.AllowsTransparency)
                {
                    window.Language = XmlLanguage.GetLanguage(_cultureInfo.Name);
                }
            }

            if(LanguageChanged != null)
            {
                LanguageChanged.Invoke(this, _cultureInfo.Name);
            }
        }
    }
}
