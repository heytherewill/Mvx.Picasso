using Square.Picasso;
using System;
using System.Globalization;

namespace Mvx.Picasso.Droid
{
	public class PicassoBasicLoadConverter : BasePicassoConverter
	{
		protected override RequestCreator CreateRequestCreator(string value, Type targetType, object parameter, CultureInfo culture)
			=> Picasso.Load(value).Fit().CenterCrop();
	}
}