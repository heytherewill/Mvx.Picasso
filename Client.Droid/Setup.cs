using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace Client.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

		protected override void InitializeLastChance()
		{
			Mvx.Picasso.PluginLoader.Instance.EnsureLoaded();

			base.InitializeLastChance();
		}

        protected override IMvxApplication CreateApp()
	        => new Core.App();
        
        protected override IMvxTrace CreateDebugTrace()
	        => new DebugTrace();
    }
}
