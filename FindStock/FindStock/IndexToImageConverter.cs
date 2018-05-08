using System;
using System.Globalization;
using Xamarin.Forms;

namespace FindStock
{
	public class IndexToImageConverter : IValueConverter
	{
		object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// XAML の ConverterParameter と SelectedIndex が同じなら on 違ったら off
			var postfix = value.Equals(Convert.ToInt32(parameter)) ? "on" : "off";
			return ImageSource.FromResource($"FindStock.Images.RadioButton_{postfix}.png"); // on か off の画像を返す
		}

		object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
