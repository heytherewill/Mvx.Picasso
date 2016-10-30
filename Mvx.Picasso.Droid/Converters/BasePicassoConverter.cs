using System;
using System.Globalization;
using MvvmCross.Platform.Converters;
using Square.Picasso;

namespace Mvx.Picasso.Droid
{
	public abstract class BasePicassoConverter : MvxValueConverter<string, RequestCreator>
	{
		protected static readonly Square.Picasso.Picasso Picasso = Square.Picasso.Picasso.With(MvvmCross.Platform.Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext);

		protected override RequestCreator Convert(string value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) return null;

			return CreateRequestCreator(value, targetType, parameter, culture);
		}

		protected abstract RequestCreator CreateRequestCreator(string value, Type targetType, object parameter, CultureInfo culture);
	}
}
