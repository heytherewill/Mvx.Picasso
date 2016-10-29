using Square.Picasso;
using MvvmCross.Platform.Droid;
using MvvmCross.Binding.Combiners;
using System.Collections.Generic;
using MvvmCross.Binding.Bindings.SourceSteps;
using System.Linq;

namespace Mvx.Picasso.Droid
{
	public class PicassoCombiner : MvxValueCombiner
	{
		private const string Fit = "Fit";
		private const string CenterCrop = "CenterCrop";
		private const string CenterInside = "CenterInside";
		private const string MemoryPolicyNoCache = "MemoryPolicyNoCache";
		private const string MemoryPolicyNoStore = "MemoryPolicyNoStore";
		private const string NetworkPolicyNoCache = "NetworkPolicyNoCache";
		private const string NetworkPolicyNoStore = "NetworkPolicyNoStore";
		private const string NoFade = "NoFade";
		private const string NoPlaceholder = "NoPlaceholder";
		private const string OnlyScaleDown = "OnlyScaleDown";
		private const string PriorityHigh = "PriorityHigh";
		private const string PriorityNormal = "PriorityNormal";
		private const string PriorityLow = "PriorityLow";
		private const string CircleTransform = "CircleTransform";

		public static bool IndicatorsEnabled
		{
			get { return Picasso.IndicatorsEnabled; }
			set { Picasso.IndicatorsEnabled = value; }
		}

		private static readonly Square.Picasso.Picasso Picasso = Square.Picasso.Picasso.With(MvvmCross.Platform.Mvx.Resolve<IMvxAndroidGlobals>().ApplicationContext);

		public override bool TryGetValue(IEnumerable<IMvxSourceStep> steps, out object value)
		{
			//Enumerate the list
			var list = steps?.ToList();
			if (list == null)
			{
				value = null;
				return false;
			}

			RequestCreator requestCreator = null;
			var resourceToLoad = list.First().GetValue();
			var resourceType = resourceToLoad.GetType();

			//Load appropriate type
			if (resourceType == typeof(string))
			{
				requestCreator = Picasso.Load((string)resourceToLoad);
			}
			else if (resourceType == typeof(int))
			{
				requestCreator = Picasso.Load((int)resourceToLoad);
			}
			else if (resourceType == typeof(string))
			{

				requestCreator = Picasso.Load((string)resourceToLoad);
			}
			else if (resourceType == typeof(string))
			{
				requestCreator = Picasso.Load((string)resourceToLoad);
			}
			else
			{
				value = null;
				return false;
			}

			//Skip the initial value and get only valid strings as options
			foreach (var option in list?.Skip(1).Select(x => x.GetValue()).OfType<string>())
			{
				switch (option)
				{
					case Fit:
						requestCreator = requestCreator.Fit();
						break;
					case CenterCrop:
						requestCreator = requestCreator.CenterCrop();
						break;
					case CenterInside:
						requestCreator = requestCreator.CenterInside();
						break;
					case MemoryPolicyNoCache:
						requestCreator = requestCreator.MemoryPolicy(MemoryPolicy.NoCache);
						break;
					case MemoryPolicyNoStore:
						requestCreator = requestCreator.MemoryPolicy(MemoryPolicy.NoStore);
						break;
					case NetworkPolicyNoCache:
						requestCreator = requestCreator.NetworkPolicy(NetworkPolicy.NoCache);
						break;
					case NetworkPolicyNoStore:
						requestCreator = requestCreator.NetworkPolicy(NetworkPolicy.NoStore);
						break;
					case NoFade:
						requestCreator = requestCreator.NoFade();
						break;
					case NoPlaceholder:
						requestCreator = requestCreator.NoPlaceholder();
						break;
					case OnlyScaleDown:
						requestCreator = requestCreator.OnlyScaleDown();
						break;
					case PriorityHigh:
						requestCreator = requestCreator.Priority(Square.Picasso.Picasso.Priority.High);
						break;
					case PriorityNormal:
						requestCreator = requestCreator.Priority(Square.Picasso.Picasso.Priority.Normal);
						break;
					case PriorityLow:
						requestCreator = requestCreator.Priority(Square.Picasso.Picasso.Priority.Low);
						break;
					case CircleTransform:
						//requestCreator = requestCreator.Transform(new CircleTransformation());
						break;
					default:
						//TODO: Placeholder, Error, Resize, ResizeDimen, Rotate, Transform
						break;
				}
			}

			value = requestCreator;
			return true;
		}
	}
}
