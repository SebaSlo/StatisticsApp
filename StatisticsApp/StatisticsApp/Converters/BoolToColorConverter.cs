using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatisticsApp.Converters
{
    public interface IValueConverter
    {
        object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }

    class BoolToColorConverter : IValueConverter
    {
        //Se llama cuando el valor pasa desde el origen de datos (view) al destino de datos (view model)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //El objeto que recibo es de tipo bool. Dependiendo ese bool, debo devolver un Color.
            //si es verdadero, cambio el color
            if ((bool)value)
            {
                return App.AppResources["DetailColor"];
            }
            else
            {
                
                return Xamarin.Forms.Color.White;
            }
        }

        //se llama cuando el valor pasa desde el destino (view model) de datos, hacia el origen (View)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
