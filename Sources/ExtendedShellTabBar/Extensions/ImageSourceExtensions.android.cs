using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;

namespace ExtendedShellTabBar.Extensions.Droid
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

        public static async Task<Bitmap> GetNativeImageAsync(
            this ImageSource source,
            Context context,
            int width,
            int height,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (source == null || source.IsEmpty)
                return null;

            var handler = source.GetHandler();
            if (handler == null)
                return null;

            try
            {
                if (handler != null)
                {
                    var image = await handler.LoadImageAsync(source, context);
                    if (image == null && source is FileImageSource fileImageSource)
                    {
                        // Maybe is xml
                        int drawableId = context.Resources.GetIdentifier(fileImageSource.File, "drawable", context.PackageName);
                        using var drawable = context.Resources.GetDrawable(drawableId, null);

                        var bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
                        using var canvas = new Canvas(bitmap);
                        drawable.SetBounds(0, 0, canvas.Width, canvas.Height);
                        drawable.Draw(canvas);

                        return bitmap;
                    }

                    return image;
                }
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
