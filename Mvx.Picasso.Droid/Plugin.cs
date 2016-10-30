using System;
using Android.Widget;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Combiners;
using MvvmCross.Platform.Converters;
using MvvmCross.Platform.Plugins;

namespace Mvx.Picasso.Droid
{
	[Preserve(AllMembers = true)]
	public class Plugin : IMvxPlugin
	{
		public void Load()
		{
			MvvmCross.Platform.Mvx.CallbackWhenRegistered<IMvxValueCombinerRegistry>(OnCombinerRegistryRegistered);
			MvvmCross.Platform.Mvx.CallbackWhenRegistered<IMvxValueConverterRegistry>(OnConverterRegistryRegistered);
			MvvmCross.Platform.Mvx.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(OnTargetBindingFactoryRegistryRegistered);
		}

		private void OnCombinerRegistryRegistered(IMvxValueCombinerRegistry registry)
		{
			registry.AddOrOverwrite("Load", new PicassoCombiner());
		}

		private void OnConverterRegistryRegistered(IMvxValueConverterRegistry registry)
		{
			registry.AddOrOverwrite("BasicLoad", new PicassoBasicLoadConverter());
		}

		private void OnTargetBindingFactoryRegistryRegistered(IMvxTargetBindingFactoryRegistry registry)
		{
			registry.RegisterCustomBindingFactory<ImageView>("Picasso", imageView => new ImageViewPicassoTargetBinding(imageView));
		}
	}
}