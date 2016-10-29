using System;
using Android.Widget;
using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target;
using Square.Picasso;

namespace Mvx.Picasso.Droid
{
	internal class ImageViewPicassoTargetBinding : MvxTargetBinding
	{
		public ImageViewPicassoTargetBinding(ImageView target)
			: base(target)
		{
		}

		public sealed override void SetValue(object value)
		{
			var requestCreator = value as RequestCreator;
			requestCreator?.Into(Target as ImageView);
		}

		public sealed override Type TargetType => typeof(RequestCreator);

		public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;
	}
}