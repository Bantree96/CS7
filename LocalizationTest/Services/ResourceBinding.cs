using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LocalizationTest.Services
{
    public class ResourceBinding : MarkupExtension
    {
        private readonly dynamic _dr;
        public string Key { get; set; }

        public ResourceBinding()
        {
            _dr = System.Windows.Application.Current.Resources["DR"] as LocalizationService;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Key))
            {
                throw new NullReferenceException("Key is a required value. ");
            }
            return _dr[Key];
        }
    }
}
