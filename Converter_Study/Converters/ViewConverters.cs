using Converter_Study.Datas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Converter_Study.Converters
{
    /// <summary>
    /// Converter : 검사상태 -> String
    /// </summary>
    class InspectionStateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((InspectionState)value)
            {
                case InspectionState.RUNNING:
                    return "RUNNING";
                case InspectionState.LOADING:
                    return "LOADING";
                default:
                    return "STOPPED";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
