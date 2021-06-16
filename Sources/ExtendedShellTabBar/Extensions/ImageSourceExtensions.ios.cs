using System;
using System.Threading;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.iOS;

namespace ExtendedShellTabBar.Extensions.iOS
{
    public static class ImageSourceExtensions
	{
		public static IImageSourceHandler GetHandler(this ImageSource source)
		{
			//Image source handler to return
			IImageSourceHandler returnValue = null;
			//check the specific source type and return the correct image source handler
			if (source is UriImageSource)
			{
				returnValue = new ImageLoaderSourceHandler();
			}
			else if (source is FileImageSource)
			{
				returnValue = new FileImageSourceHandler();
			}
			else if (source is StreamImageSource)
			{
				returnValue = new StreamImagesourceHandler();
			}
			return returnValue;
		}

		public static async Task<UIImage> GetNativeImageAsync(this ImageSource source, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (source == null || source.IsEmpty)
				return null;

			var handler = source.GetHandler();
			if (handler == null)
				return null;

			try
			{
				float scale = (float)UIScreen.MainScreen.Scale;
				return await handler.LoadImageAsync(source, scale: scale, cancelationToken: cancellationToken);
			}
			catch (OperationCanceledException)
			{
				Log.Warning("Image loading", "Image load cancelled");
			}
			catch (Exception ex)
			{
				Log.Warning("Image loading", $"Image load failed: {ex}");
			}

			return null;
		}
	}
}
