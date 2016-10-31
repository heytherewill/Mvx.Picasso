using Android.Graphics;
using Java.Lang;
using Square.Picasso;

namespace Mvx.Picasso.Droid
{
	public class CircleTransform : Object, ITransformation
	{
		public Bitmap Transform(Bitmap source)
		{
			var size = Math.Min(source.Width, source.Height);

			var x = (source.Width - size) / 2;
			var y = (source.Height - size) / 2;

			var squaredBitmap = Bitmap.CreateBitmap(source, x, y, size, size);
			if (squaredBitmap != source)
			{
				source.Recycle();
			}

			var bitmap = Bitmap.CreateBitmap(size, size, source.GetConfig());

			var canvas = new Canvas(bitmap);
			var paint = new Paint();
			var shader = new BitmapShader(squaredBitmap, Shader.TileMode.Clamp, Shader.TileMode.Clamp);
			paint.SetShader(shader);
			paint.AntiAlias = true;

			var r = size / 2f;
			canvas.DrawCircle(r, r, r, paint);

			squaredBitmap.Recycle();
			return bitmap ?? source;
		}

		public string Key { get; } = "circle";
	}
}