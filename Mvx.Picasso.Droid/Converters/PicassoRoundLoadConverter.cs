using Square.Picasso;
using System;
using System.Globalization;

namespace Mvx.Picasso.Droid
{
	public class PicassoRoundLoadConverter : PicassoBasicLoadConverter
	{
		protected override RequestCreator CreateRequestCreator(string value, Type targetType, object parameter, CultureInfo culture)
			=> base.CreateRequestCreator(value, targetType, parameter, culture).Transform(new CircleTransform());
	}
}