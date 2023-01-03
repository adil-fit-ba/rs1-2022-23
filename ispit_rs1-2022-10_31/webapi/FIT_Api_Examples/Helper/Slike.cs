using System.Drawing;
using System.Net.Mime;
using SkiaSharp;

namespace FIT_Api_Examples.Helper
{
    public class Slike
    {
        internal static byte[]? resize(byte[] slika_bajtovi, int size)
        {
            const int quality = 75;

            using var input = new MemoryStream(slika_bajtovi);
            using var inputStream = new SKManagedStream(input);
            using var original = SKBitmap.Decode(inputStream);
            int width, height;
            if (original.Width > original.Height)
            {
                width = size;
                height = original.Height * size / original.Width;
            }
            else
            {
                width = original.Width * size / original.Height;
                height = size;
            }

            using var resized = original
                .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3);

            if (resized == null) return null;

            using var image = SKImage.FromBitmap(resized);
            
            return image.Encode(SKEncodedImageFormat.Png, quality)
                .ToArray();
        }
    }

}